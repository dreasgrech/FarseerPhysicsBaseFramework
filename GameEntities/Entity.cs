using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FarseerPhysicsBaseFramework.GameEntities
{
    public abstract class Entity : IPlayable
    {
        public Game Game { get; private set; }

        public abstract Vector2 Position { get; set; }
        public virtual float Angle { get; set; }
        public virtual float X { get { return Position.X; } set { Position = new Vector2(value, Position.Y); } }
        public virtual float Y { get { return Position.Y; } set { Position = new Vector2(Position.X, value); } }
        public Vector2 Center { get; set; }

        protected Entity(Game game)
        {
            Game = game;
        }

        public virtual void Draw(GameTime gametime){}
        public virtual void Update(GameTime gametime) {}

    }
}
