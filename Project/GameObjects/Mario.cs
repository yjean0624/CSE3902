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
        private readonly float yVelocityThreshholdForFalling = Config.GetPlayerYVelocityThreshholdForFalling();
        private readonly float xVelocityThreshholdForIdling = Config.GetPlayerXVelocityThreshholdForIdling();
        public float Speed { get { return Config.GetPlayerMovementSpeed() * speedMultiplier; } }
        private float speedMultiplier;

        public Mario(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.SmallMarioIdleRight);
            HealthState = new SmallMarioState(this);
            MovementState = new RightFacingMarioState(this);
            Physics = new Physics(location,true);
            speedMultiplier = 1.0f;
        }
        public void CollectGreenMushroom()
        {
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
            speedMultiplier -= Config.GetSpeedBoostDeteriorationRate();
            if(speedMultiplier < 1.0f)
            {
                speedMultiplier = 1.0f;
            }
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
        private void UpdateSprite()
        {
            //needs to also update the player position so the bottom of the player stays in the same place
            ISprite currentSprite = sprite;
            sprite = SpriteMachine.Instance.CreateSprite(HealthState.GetType().Name + MovementState.GetType().Name);
            Physics.yPosition += currentSprite.GetHeight() - sprite.GetHeight();
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
                startingPositionOfFireball.Y = Physics.yPosition + sprite.GetHeight()/2;
                startingVelocityOfFireball.X = Physics.xVelocity + Config.GetFireBallXVelocity();
            }
            else
            {
                startingPositionOfFireball.X = Physics.xPosition;
                startingPositionOfFireball.Y = Physics.yPosition + sprite.GetHeight()/2;
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
        public void Kill()
        {
            GameManager.Instance.Replace(this, new DeadMario(Location(), this));
        }

        public bool IsGrounded()
        {
            return MovementState.IsGrounded();
        }
        public void Boost()
        {
            speedMultiplier += Config.GetAdditionalMultiplierPerBoost();
        }
    }
}
