using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Sprites
{
    public interface IMarioSprite : ISprite
    {
        void SetToJumping(bool facingRight);
        void SetToStanding(bool facingRight);
        void SetToRunning(bool facingRight);
        void SetToCrouching(bool facingRight);
    }
}
