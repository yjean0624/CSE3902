using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.GameObjects.MarioStates;
using Project.Sprites;
using System;

namespace Project.GameObjects
{
    public class Mario : GameObject, IMario
    {
        private IHealthState HealthState;
        private IMovementState MovementState;
        private int lives;
        private readonly float yVelocityThreshholdForFalling = Config.GetPlayerYVelocityThreshholdForFalling();
        private readonly float xVelocityThreshholdForIdling = Config.GetPlayerXVelocityThreshholdForIdling();

        public Mario(Vector2 location, int lives) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.SmallMarioIdleRight);
            HealthState = new SmallMarioState(this);
            MovementState = new RightFacingMarioState(this);
            Physics = new Physics(location,true);
            this.lives = lives;
        }

        public void LoseLife()
        {
            lives--;
        }
        public void GainLife()
        {
            lives++;
        }
        public void CollectGreenMushroom()
        {
            GainLife();
        }

        public override void Update(GameTime gameTime)
        {
            Physics.Update(gameTime);
            HealthState.Update(gameTime);
            MovementState.Update(gameTime);
            if(Physics.yVelocity > yVelocityThreshholdForFalling)
            {
                MovementState.Fall();
            }
            if (Physics.xVelocity < xVelocityThreshholdForIdling && Physics.xVelocity > -xVelocityThreshholdForIdling)
            {
                MovementState.Idle();
            }
            sprite.Update(gameTime);
            if (Physics.yPosition > Config.GetDespawnThreshhold())
            {
                this.TakeDamage();
            }
            Console.WriteLine(Physics.xVelocity);
        }
        public void SetHealthState(IHealthState healthState)
        {
            HealthState = healthState;
            UpdateSprite();
        }
        public void SetMovementState(IMovementState movementState)
        {
            MovementState = movementState;
            UpdateSprite();
        }
        public void UpdateSprite()
        {
            sprite = SpriteMachine.Instance.CreateSprite(HealthState.GetType().Name + MovementState.GetType().Name);
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
        public void MoveLeft()
        {
            MovementState.MoveLeft();
        }
        public void MoveRight()
        {
            MovementState.MoveRight();
        }
        public void Jump()
        {
            MovementState.Jump();
        }
        public void Crouch()
        {
            MovementState.Crouch();
        }
        public void CollectBrownMushroom()
        {
            HealthState.CollectBrownMushroom();
        }
        public void CollectFlower()
        {
            HealthState.CollectFlower();
        }
        public void CollectStar()
        {
            StarMario starMario = new StarMario(Physics, this);
            GameManager.Instance.Replace(this, starMario);
        }
        public bool IsSmall()
        {
            return HealthState.IsSmall();
        }
        public bool IsBig()
        {
            return HealthState.IsBig();
        }
        public bool IsFire()
        {
            return HealthState.IsFire();
        }
        public bool IsCrouching()
        {
            return MovementState.IsCrouching();
        }
        public void TakeDamage()
        {
            HealthState.TakeDamage();
        }

        public int GetLives()
        {
            return lives;
        }

        public void StopJumping()
        {
            MovementState.StopJumping();
        }

        public void Idle()
        {
            MovementState.Idle();
        }

        public void Stand()
        {
            MovementState.Stand();
        }

        public override void Ground()
        {
            MovementState.Ground();
        }

        public void Fall()
        {
            MovementState.Fall();
        }
        public void ThrowFireball()
        {
            Vector2 startingPositionOfFireball = new Vector2();
            Vector2 startingVelocityOfFireball = new Vector2();
            startingVelocityOfFireball.Y = Physics.yVelocity;
            if (Physics.xVelocity >= 0)
            {
                startingPositionOfFireball.X = Physics.xPosition + sprite.GetWidth();
                startingPositionOfFireball.Y = Physics.yPosition + sprite.GetHeight();
                startingVelocityOfFireball.X = Physics.xVelocity + Config.GetFireBallXVelocity();
            }
            else
            {
                startingPositionOfFireball.X = Physics.xPosition;
                startingPositionOfFireball.Y = Physics.yPosition;
                startingVelocityOfFireball.X = Physics.xVelocity - Config.GetFireBallXVelocity();
            }

            HealthState.ThrowFireball(startingPositionOfFireball, startingVelocityOfFireball);
        }
        public void StopThrowingFireball()
        {
            HealthState.StopThrowingFireball();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, Location(), color);
        }
    }
}
