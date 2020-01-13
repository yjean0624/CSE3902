using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Enemies
{

    public class KoopaShell: Enemy
    {
        public KoopaShell(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaShell);
            Physics.xVelocity = 0;
        }

        public void MoveLeft()
        {
            Physics.xVelocity = -Config.GetKoopaShellMovingSpeed();
        }

        public void MoveRight()
        {
            Physics.xVelocity = Config.GetKoopaShellMovingSpeed();
        }

        public override void Fall()
        {
            ReversedKoopaShell reversedKoopaShell = new ReversedKoopaShell(this.Location());
            GameManager.Instance.Replace(this, reversedKoopaShell);
        }
    }
}
