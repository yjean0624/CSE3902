using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public class ThrowingFireballState : FireballThrowingState
    {
        public ThrowingFireballState(FireMarioState fireMarioState) : base(fireMarioState)
        {
        }

        public override void StopThrowingFireball()
        {
            fireMarioState.fireballThrowingState = new NotThrowingFireballState(fireMarioState);
        }
    }
}
