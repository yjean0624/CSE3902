using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Enemies
{
    public class Koopa : Enemy
    {
        public Koopa(Vector2 location): base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaRight);
            Physics.yAcceleration = Config.GetGravity();
            Physics.xVelocity = Config.GetEnemyMovingSpeed();
        }

        public void BecomeStaticKS()
        {
            Physics.xVelocity = 0;
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaShell);
            
        }

        public override void ChangeDirection()
        {
            if(Physics.xVelocity > 0)
            {
                sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaLeft);
            }else if (Physics.xVelocity < 0)
            {
                sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaRight);
            }
            Physics.xVelocity *= -1;
        }

        public override void Fall()
        {
            ReversedKoopaShell reversedKoopaShell = new ReversedKoopaShell(this.Location());
            GameManager.Instance.Replace(this, reversedKoopaShell);
        }
    }
}

