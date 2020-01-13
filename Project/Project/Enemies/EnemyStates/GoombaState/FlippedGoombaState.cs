using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Enemies.EnemyStates
{
    public class FlippedGoombaState: IGoombaState
    {
        private Goomba goomba;
        public FlippedGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
            
            this.goomba.Physics.yPosition += 2;
            this.goomba.Physics.yAcceleration = Config.GetGravity();
        }

        public void BeFlipped()
        {
        }

        public void BeStomped()
        {
        }

        public void ChangeDirection()
        {
        }

        public void Update(GameTime gameTime)
        {
            this.goomba.Physics.yPosition += 2;
            this.goomba.Physics.yAcceleration = Config.GetGravity();

        }
    }
}
