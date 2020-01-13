using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Enemies
{

    public class KoopaShell: Enemy
    {
        private bool moveLeft;
        private bool still;
        public KoopaShell(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaShell);
            moveLeft = false;
            still = false;
        }

        public void Kick()
        {
            moveLeft = true;
        }

        public void Still()
        {
            still = true;
        }

        public override void ChangeDirection()
        {
            moveLeft = !moveLeft;
        }

        public override void Update(GameTime gameTime)
        {
            if (reversedFalling)
            {
                Physics.yPosition += 4;
                Physics.yAcceleration = Config.GetGravity();
                sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaShellReversed);
            }
            if (moveLeft)
            {
                Physics.xPosition -= 4;
                Physics.xAcceleration = 8;
            }
            else
            {
                Physics.xPosition += 4;
                Physics.xAcceleration = 8;
            }
            if (still)
            {
                sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaShell);
            }
            Physics.Update(gameTime);
            sprite.Update(gameTime);
        }
    }
}
