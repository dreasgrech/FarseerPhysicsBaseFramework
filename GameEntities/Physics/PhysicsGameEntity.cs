using System.Collections.Generic;
using FarseerPhysics.Common;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.Common.PolygonManipulation;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysicsWP7Framework.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FarseerPhysicsWP7Framework.GameEntities.Physics
{
    public class PhysicsGameEntity:Entity
    {
        protected World World { get; private set; }
        private Body body;
        public Body Body
        {
            get { return body; }
            set
            {
                body = value;
                body.UserData = this;
            }
        }

        private PhysicsGameEntity(Game game, World world): base(game)
        {
            World = world;
        }
        
        public PhysicsGameEntity(Game game, World world, Body body, Vector2 origin):this(game,world)
        {
            Body = body;
            Center = origin;
        }

        /// <summary>
        /// Construct a FPE Body from the given texture and density
        /// </summary>
        /// <param name="game"></param>
        /// <param name="world"></param>
        /// <param name="texture"></param>
        /// <param name="bodyType"></param>
        /// <param name="density"></param>
        public PhysicsGameEntity(Game game, World world, Texture2D texture, BodyType bodyType, float density):this(game,world)
        {
            //Create an array to hold the data from the texture
            uint[] data = new uint[texture.Width * texture.Height];

            //Transfer the texture data to the array
            texture.GetData(data);

            var vertices = PolygonTools.CreatePolygon(data, texture.Width, true);
            ConstructFromVertices(world,vertices,density);
            Body.BodyType = bodyType;
        }

        /// <summary>
        /// Constructs a FPE Body from the given list of vertices and density
        /// </summary>
        /// <param name="game"></param>
        /// <param name="world"></param>
        /// <param name="vertices">The collection of vertices in DISPLAY UNITS</param>
        /// <param name="bodyType"></param>
        /// <param name="density"></param>
        public PhysicsGameEntity(Game game, World world, Vertices vertices, BodyType bodyType, float density):this(game,world)
        {
            ConstructFromVertices(world,vertices,density);
            Body.BodyType = bodyType;
        }

        private void ConstructFromVertices(World world, Vertices vertices, float density)
        {
            //We need to find the real center (centroid) of the vertices for 2 reasons:

            //1. To translate the vertices so the polygon is centered around the centroid.
            var centroid = -vertices.GetCentroid();
            vertices.Translate(ref centroid);

            //2. To draw the texture the correct place.
            Center = -centroid;

            //We simplify the vertices found in the texture.
            vertices = SimplifyTools.ReduceByDistance(vertices, 4f);

            //Since it is a concave polygon, we need to partition it into several smaller convex polygons
            //List<Vertices> list = BayazitDecomposer.ConvexPartition(textureVertices);
            List<Vertices> list = EarclipDecomposer.ConvexPartition(vertices);

            //Now we need to scale the vertices (result is in pixels, we use meters)
            //At the same time we flip the y-axis. [I'm still not sure about this; why the flip?]
            //var scale = new Vector2(0.01f, -0.01f);
            var scale = new Vector2(0.01f, 0.01f); //currently keeping the y-axis as it is (ie not flipped)

            foreach (Vertices newVertices in list)
            {
                newVertices.Scale(ref scale);

                //When we flip the y-axis, the orientation can change.
                //We need to remember that FPE works with CCW polygons only.
                newVertices.ForceCounterClockWise();
            }

            Body = BodyFactory.CreateCompoundPolygon(world, list, density);
        }

        public override Vector2 Position
        {
            get { return ConvertUnits.ToDisplayUnits(Body.Position); }
            set { Body.Position = ConvertUnits.ToSimUnits(value); }
        }

        public override float Angle
        {
            get
            {
                return ConvertUnits.ToDisplayUnits(Body.Rotation);
            }
            set
            {
                Body.Rotation = ConvertUnits.ToSimUnits(value);
            }
        }
    }
}
