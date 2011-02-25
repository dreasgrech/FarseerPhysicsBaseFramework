using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FarseerPhysicsWP7Framework.GameEntities
{
    public abstract class Entity : IPlayable
    {
        public Game Game { get; private set; }
        protected SpriteBatch SpriteBatch { get; private set; }
        protected GraphicsDeviceManager GraphicsDeviceManager { get; private set; }
        protected GraphicsDevice GraphicsDevice { get { return GraphicsDeviceManager.GraphicsDevice; } }

        public abstract Vector2 Position { get; set; }
        public virtual float Angle { get; set; }
        public virtual float X { get { return Position.X; } set { Position = new Vector2(value, Position.Y); } }
        public virtual float Y { get { return Position.Y; } set { Position = new Vector2(Position.X, value); } }
        public Vector2 Center { get; set; }

        protected Entity(Game game)
        {
            Game = game;
            SpriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            GraphicsDeviceManager = (GraphicsDeviceManager)game.Services.GetService(typeof(GraphicsDeviceManager));
        }

        public virtual void Draw(GameTime gametime){}
        public virtual void Update(GameTime gametime) {}

        public int ScreenWidth { get { return GraphicsDevice.Viewport.Width; } }
        public int ScreenHeight { get { return GraphicsDevice.Viewport.Height; } }
    }
}
