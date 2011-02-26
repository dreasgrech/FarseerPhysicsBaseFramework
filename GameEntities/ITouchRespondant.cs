using Microsoft.Xna.Framework.Input.Touch;

namespace FarseerPhysicsWP7Framework.GameEntities
{
    public interface ITouchRespondant
    {
        void RespondToTouch(GestureSample gesture);
    }
}
