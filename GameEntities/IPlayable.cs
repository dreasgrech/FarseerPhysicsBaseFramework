using Microsoft.Xna.Framework;

namespace FarseerPhysicsBaseFramework.GameEntities
{
    public interface IPlayable
    {
        void Draw(GameTime gameTime);
        void Update(GameTime gameTime);
    }
}
