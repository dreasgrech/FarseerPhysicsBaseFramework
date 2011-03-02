using System.Collections.Generic;
using FarseerPhysics.Common;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.Common.PolygonManipulation;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysicsBaseFramework.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FarseerPhysicsBaseFramework.GameEntities.Physics
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

        public Category CollisionCategory { get; private set; }

        private PhysicsGameEntity(Game game, World world, Category collisionCategory): base(game)
        {
            World = world;
            CollisionCategory = collisionCategory;
        }
        
        public PhysicsGameEntity(Game game, World world, Category collisionCategory, Body body, Vector2 origin):this(game,world,collisionCategory)
        {
            Body = body;
            Center = origin;
            Body.CollisionCategories = collisionCategory;
        }

        /// <summary>
        /// Construct a FPE Body from the given texture and density
        /// </summary>
        /// <param name="game"></param>
        /// <param name="world"></param>
        /// <param name="texture"></param>
        /// <param name="bodyType"></param>
        /// <param name="density"></param>
        public PhysicsGameEntity(Game game, World world, Category collisionCategory, Texture2D texture, BodyType bodyType, float density):this(game,world,collisionCategory)
        {
            //Create an array to hold the data from the texture
            uint[] data = new uint[texture.Width * texture.Height];

            //Transfer the texture data to the array
            texture.GetData(data);

            var vertices = PolygonTools.CreatePolygon(data, texture.Width, true);
            ConstructFromVertices(world,vertices,density);
            Body.BodyType = bodyType;
            Body.CollisionCategories = collisionCategory;
        }

        /// <summary>
        /// Constructs a FPE Body from the given list of vertices and density
        /// </summary>
        /// <param name="game"></param>
        /// <param name="world"></param>
        /// <param name="vertices">The collection of vertices in display units (pixels)</param>
        /// <param name="bodyType"></param>
        /// <param name="density"></param>
        public PhysicsGameEntity(Game game, World world, Category collisionCategory, Vertices vertices, BodyType bodyType, float density):this(game,world,collisionCategory)
        {
            ConstructFromVertices(world,vertices,density);
            Body.BodyType = bodyType;
            Body.CollisionCategories = collisionCategory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="world"></param>
        /// <param name="vertices">The collection in vertices in display units (pixels)</param>
        /// <param name="density"></param>
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
            List<Vertices> list = BayazitDecomposer.ConvexPartition(vertices);
            //List<Vertices> list = EarclipDecomposer.ConvexPartition(vertices);

            //Now we need to scale the vertices (result is in pixels, we use meters)
            Vector2 vertScale = new Vector2(ConvertUnits.SimUnitsToDisplayUnitsRatio);// new Vector2(ConvertUnits.ToSimUnits(1)) * _scale;

            foreach (Vertices newVertices in list)
            {

                newVertices.Scale(ref vertScale);
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
                return Body.Rotation;
            }
            set
            {
                Body.Rotation = value;
            }
        }
    }
}
