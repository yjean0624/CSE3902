using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Enemies.EnemyStates
{
    public class StompedGoombaState: IGoombaState
    {
        private Goomba goomba;
        public StompedGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
        }

        public void ChangeDirection()
        {
        }

        public void BeStomped()
        {

        }

        public void BeFlipped()
        {

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
