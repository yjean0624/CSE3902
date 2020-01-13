using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Enemies
{
    public class Goomba : Enemy
    {
        private bool stomped;
        private bool moveLeft;
        public Goomba(Vector2 location): base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.Goomba);
            Physics = new Physics(location);
            stomped = false;
            moveLeft = true;
            Physics.yAcceleration = Config.GetGravity();
        }

        public void Stomp()
        {
            stomped = true;
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.Stomp);
        }

        
        public override void ChangeDirection()
        {
            moveLeft = !moveLeft;
        }

        public override void Update(GameTime gameTime)
        {
            if(!dead)
            {
                if (moveLeft)
                {
                    Physics.xPosition -= 0.5f;
                }
                else
                {
                    Physics.xPosition += 0.5f;
                }
                
            }
            else
            {
                if (stomped)
                {
                    sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.DeadGoomba);
                    Clean();
                }
                if (reversedFalling)
                {
                    Physics.yPosition += 2;
                    Physics.yAcceleration = Config.GetGravity();
                    sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.GoombaReversed);
                }
            }
            Physics.Update(gameTime);
            sprite.Update(gameTime);
        }
    }
}