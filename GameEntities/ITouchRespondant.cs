using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input.Touch;

namespace WP7Physics.Entities.AbstractEntities
{
    interface ITouchRespondant
    {
        void RespondToTouch(GestureSample gesture);
    }
}
