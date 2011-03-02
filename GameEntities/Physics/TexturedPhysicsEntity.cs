using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysicsBaseFramework.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FarseerPhysicsBaseFramework.GameEntities.Physics
{
    public class TexturedPhysicsEntity:PhysicsGameEntity
    {
        public TexturedGameEntity MainTexture { get; set; }

        /// <summary>
        /// Initializes a new Textured (drawable) Physics Entity by converting the given texture to vertices
        /// </summary>
        /// <param name="game"></param>
        /// <param name="world"></param>
        /// <param name="texturedGameEntity"></param>
        /// <param name="density"></param>
        /// <param name="type"></param>
        public TexturedPhysicsEntity(Game game, World world, Category collisionCategory, TexturedGameEntity texturedGameEntity, float density, BodyType type) : base(game, world, collisionCategory, texturedGameEntity.MainTexture, type, density)
        {
            Initialize(texturedGameEntity);
        }

        /// <summary>
        /// Initializes a new Textured (drawable) Physics Entity from the given body
        /// </summary>
        /// <param name="game"></param>
        /// <param name="world"></param>
        /// <param name="texturedGameEntity"></param>
        /// <param name="body"></param>
        /// <param name="origin">The local origin of the shape in display units (pixels)</param>
        public TexturedPhysicsEntity(Game game, World world, Category collisionCategory, TexturedGameEntity texturedGameEntity, Body body, Vector2 origin) : base(game, world, collisionCategory, body, origin)
        {
            Initialize(texturedGameEntity);
        }

        /// <summary>
        /// Initializes a new Textured (drawable) Physics Entity from the given collection of vertices
        /// </summary>
        /// <param name="game"></param>
        /// <param name="world"></param>
        /// <param name="texturedGameEntity"></param>
        /// <param name="vertices">The collection of vertices representing the shape in display units (pixels)</param>
        /// <param name="bodyType"></param>
        /// <param name="density"></param>
        public TexturedPhysicsEntity(Game game, World world, Category collisionCategory, TexturedGameEntity texturedGameEntity, Vertices vertices, BodyType bodyType, float density) : base(game, world, collisionCategory, vertices, bodyType, density)
        {
            Initialize(texturedGameEntity);
        }

        private void Initialize(TexturedGameEntity texturedGameEntity)
        {
            MainTexture = texturedGameEntity;
            Position = texturedGameEntity.Position;
        }

        public override sealed Vector2 Position
        {
            get { return base.Position; }
            set { base.Position = value; }
        }

        /// <summary>
        /// Returns the width of the texture in display units (pixels)
        /// </summary>
        public int Width
        {
            get { return MainTexture.Width; }
        }

        /// <summary>
        /// Returns the height of the texture in display units (pixels)
        /// </summary>
        public int Height
        {
            get { return MainTexture.Height; }
        }

        public override void Draw(GameTime gametime)
        {
            MainTexture.SpriteBatch.Draw(MainTexture.MainTexture, Position, null, Color.White, Angle, Center, 1f, SpriteEffects.None, MainTexture.ZIndex);
        }
    }
}
