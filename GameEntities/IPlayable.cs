using Microsoft.Xna.Framework;

namespace FarseerPhysicsWP7Framework.GameEntities
{
    interface IPlayable
    {
        void Draw(GameTime gameTime);
        void Update(GameTime gameTime);
    }
}
