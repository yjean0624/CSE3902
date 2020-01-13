using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Enemies.EnemyStates
{
    public class RightMovingGoombaState: IGoombaState
    {
        private Goomba goomba;
        public RightMovingGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
        }

        public void BeFlipped()
        {
            goomba.state = new FlippedGoombaState(goomba);
        }

        public void BeStomped()
        {
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.Stomp);
            goomba.state = new StompedGoombaState(goomba);
        }

        public void ChangeDirection()
        {
            goomba.state = new LeftMovingGoombaState(goomba);
        }

        public void Update(GameTime gameTime)
        {
            goomba.Physics.xPosition += 0.5f;
        }
    }
}
