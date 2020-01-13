using Project.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;

namespace Project.GameObjects
{
    public class StarMario : GameObject, IMario
    {
        private Mario baseMario;
        private float millisecondsLeft = Config.GetStarMarioTimeInMilliseconds();
        public StarMario(Physics physics, Mario baseMario) : base(new Vector2(physics.xPosition,physics.yPosition))
        {
            this.Physics = physics;
            this.baseMario = baseMario;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            millisecondsLeft -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(millisecondsLeft <= 0.0f)
            {
                baseMario.Physics = this.Physics;
                GameManager.Instance.Replace(this, baseMario);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            baseMario.Draw(spriteBatch, Color.Gold);
        }
        public void CollectFlower()
        {
            baseMario.CollectFlower();
        }
        public void SetXPosition(int x)
        {
            //depriciated - all uses need to refer to the Physics now
            Physics.xPosition = x;
            Physics.xVelocity = 0;
        }
        public void SetYPosition(int y)
        {
            //depriciated - all uses need to refer to the Physics now
            Physics.yPosition = y;
            Physics.yVelocity = 0;
        }
        public void CollectBrownMushroom()
        {
            baseMario.CollectBrownMushroom();
        }

        public void CollectStar()
        {
            millisecondsLeft = Config.GetStarMarioTimeInMilliseconds();
        }

        public void Crouch()
        {
            baseMario.Crouch();
        }

        public void Fall()
        {
            baseMario.Fall();
        }

        public int GetLives()
        {
            return baseMario.GetLives();
        }

        public override void Ground()
        {
            baseMario.Ground();
        }

        public void Idle()
        {
            baseMario.Idle();
        }

        public bool IsBig()
        {
            return baseMario.IsBig();
        }

        public bool IsFire()
        {
            return baseMario.IsFire();
        }

        public bool IsSmall()
        {
            return baseMario.IsSmall();
        }
        public bool IsCrouching()
        {
            return baseMario.IsCrouching();
        }

        public void Jump()
        {
            baseMario.Jump();
        }

        public void MoveLeft()
        {
            baseMario.MoveLeft();
        }

        public void MoveRight()
        {
            baseMario.MoveRight();
        }

        public void Stand()
        {
            baseMario.Stand();
        }

        public void StopJumping()
        {
            baseMario.StopJumping();
        }

        public void TakeDamage()
        {
            //Star mario does not take damage
        }

        public void ThrowFireball()
        {
            //not sure is star mario can thrown fireballs
            baseMario.ThrowFireball();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            baseMario.Draw(spriteBatch, color);
        }

        public void StopThrowingFireball()
        {
            //not sure if star mario can throw fireballs
            baseMario.StopThrowingFireball();
        }

        public void CollectGreenMushroom()
        {
            baseMario.CollectGreenMushroom();
        }

        public void LoseLife()
        {
            baseMario.LoseLife();
        }

        public void GainLife()
        {
            baseMario.GainLife();
        }
    }
}
