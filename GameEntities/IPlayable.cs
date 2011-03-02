using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FarseerPhysicsBaseFramework.GameEntities
{
    public interface IPlayable
    {
        void Draw(GameTime gameTime);
        void Update(GameTime gameTime);
    }
}
