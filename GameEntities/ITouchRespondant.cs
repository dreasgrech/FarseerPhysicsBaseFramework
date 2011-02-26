using Microsoft.Xna.Framework.Input.Touch;

namespace FarseerPhysicsBaseFramework.GameEntities
{
    public interface ITouchRespondant
    {
        void RespondToTouch(GestureSample gesture);
    }
}
