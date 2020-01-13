

using Microsoft.Xna.Framework;

namespace Project.Enemies.EnemyStates
{
    public class LeftMovingGoombaState: IGoombaState
    {
        private Goomba goomba;
        public LeftMovingGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
        }

        public void ChangeDirection()
        {
            goomba.state = new RightMovingGoombaState(goomba);
        }

        public void BeStomped()
        {
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.Stomp);
            goomba.state = new StompedGoombaState(goomba);
        }

        public void BeFlipped()
        {
            goomba.state = new FlippedGoombaState(goomba);
        }

        public void Update(GameTime gameTime)
        {
            goomba.Physics.xPosition -= 0.5f;
        }
    }
}
