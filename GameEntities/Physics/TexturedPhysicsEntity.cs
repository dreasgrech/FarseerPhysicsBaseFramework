using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FarseerPhysicsWP7Framework.GameEntities.Physics
{
    class TexturedPhysicsEntity:PhysicsGameEntity
    {
        public TexturedGameEntity MainTexture { get; set; }

        public TexturedPhysicsEntity(Game game, World world, TexturedGameEntity texturedGameEntity, float density, BodyType type) : base(game, world, texturedGameEntity.MainTexture, type, density)
        {
            MainTexture = texturedGameEntity;
            Position = texturedGameEntity.Position;
        }
        public TexturedPhysicsEntity(Game game, World world, TexturedGameEntity texturedGameEntity, Body body, Vector2 origin) : base(game, world, body, origin)
        {
            MainTexture = texturedGameEntity;
            Position = texturedGameEntity.Position;
        }

        public override sealed Vector2 Position
        {
            get { return base.Position; }
            set { base.Position = value; }
        }

        public TexturedPhysicsEntity(Game game, World world, TexturedGameEntity texturedGameEntity, Vertices vertices, BodyType bodyType, float density): base(game,world,vertices,bodyType,density)
        {
            MainTexture = texturedGameEntity;
            Position = texturedGameEntity.Position;
        } 

        public int Width
        {
            get { return MainTexture.Width; }
        }

        public int Height
        {
            get { return MainTexture.Height; }
        }

        public override void Draw(GameTime gametime)
        {
            SpriteBatch.Draw(MainTexture.MainTexture, Position, null, Color.White, Body.Rotation, Center, new Vector2(1, 1f), SpriteEffects.None, MainTexture.ZIndex);
        }
    }
}
