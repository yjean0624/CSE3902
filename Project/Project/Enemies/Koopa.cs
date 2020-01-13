using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Enemies
{
    public class Koopa : Enemy
    {
        private bool moveLeft;
        public Koopa(Vector2 location): base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaLeft);
            moveLeft = true;
            Physics.yAcceleration = Config.GetGravity();
        }


        public override void ChangeDirection()
        {
            if (moveLeft)
            {
                sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaRight);
                moveLeft = false;
            }
            else
            {
                sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaLeft);
                moveLeft = true;
            }
        }


        public override void Update(GameTime gameTime)
        {
            if (moveLeft)
            {
                Physics.xPosition -= 0.5f;
            }
            else
            {
                Physics.xPosition += 0.5f;
            }
            Physics.Update(gameTime);
            sprite.Update(gameTime);
        }
    }
}

