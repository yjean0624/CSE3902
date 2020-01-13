using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public abstract class MovementMarioState : IMovementState
    {
        protected Mario gameObject;
        protected MovementMarioState(Mario gameObject)
        {
            this.gameObject = gameObject;
        }

        public virtual void MoveLeft()
        {
            gameObject.Physics.xVelocity -= Config.GetPlayerMovementSpeed();
        }
        public virtual void MoveRight()
        {
            gameObject.Physics.xVelocity += Config.GetPlayerMovementSpeed();
        }
        public virtual void Jump()
        {

        }
        public virtual void Crouch()
        {

        }
        public virtual void Idle()
        {

        }
        public virtual void Fall()
        {

        }
        public virtual void Stand()
        {

        }
        public virtual void Ground()
        {
            gameObject.Physics.yVelocity = 0.0f;
        }
        public virtual void StopJumping()
        {

        }
        public abstract bool IsFacingLeft();
        public abstract bool IsFacingRight();
        public virtual bool IsRunning()
        {
            return false;
        }
        public virtual bool IsJumping()
        {
            return false;
        }
        public virtual bool IsCrouching()
        {
            return false;
        }
        public virtual bool IsGrounded()
        {
            return true;
        }
        public virtual bool IsFalling()
        {
            return false;
        }
        public abstract void Update(GameTime gameTime);
    }
}
