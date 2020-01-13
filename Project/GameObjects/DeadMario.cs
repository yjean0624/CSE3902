using Project.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;

namespace Project.GameObjects
{
    class DeadMario : GameObject, IMario
    {
        private Mario baseMario;
        public DeadMario(Vector2 location, Mario baseMario) : base(location)
        {
            this.Physics = new Physics(location, 0f, Config.GetPlayerInitialYVelocyWhenDead());
            this.sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.DeadMario);
            this.baseMario = baseMario;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location());
        }
        public void CollectFlower()
        {
        }
        public void SetXPosition(int x)
        {
        }
        public void SetYPosition(int y)
        {
        }
        public void CollectBrownMushroom()
        {
        }

        public void CollectStar()
        {
        }

        public void Crouch()
        {
        }

        public void Fall()
        {
        }

        public override void Ground()
        {
        }

        public void Idle()
        {
        }

        public bool IsBig()
        {
            return false;
        }

        public bool IsFire()
        {
            return false;
        }

        public bool IsSmall()
        {
            return false;
        }
        public bool IsCrouching()
        {
            return false;
        }
        public void Jump()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void Stand()
        {
        }

        public void StopJumping()
        {
        }

        public void TakeDamage()
        {
        }

        public void ThrowFireball()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
        }

        public void StopThrowingFireball()
        {
        }

        public void CollectGreenMushroom()
        {
        }

        public void Kill()
        {
        }

        public bool IsGrounded()
        {
            return baseMario.IsGrounded();
        }

        public void Boost()
        {
        }
    }
}
