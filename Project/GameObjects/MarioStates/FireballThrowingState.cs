using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public abstract class FireballThrowingState : IFireballThrowingState
    {
        protected FireMarioState fireMarioState;
        protected FireballThrowingState(FireMarioState fireMarioState)
        {
            this.fireMarioState = fireMarioState;
        }

        public virtual void StopThrowingFireball()
        {
        }

        public virtual void ThrowFireball(Vector2 location, Vector2 velocity)
        {
        }
    }
}
