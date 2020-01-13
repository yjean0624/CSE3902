using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    class RightFallingMarioState : MovementMarioState
    {
        public RightFallingMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
        }
        public override void Ground()
        {
            gameObject.SetMovementState(new RightFacingMarioState(gameObject));
        }
        public override bool IsFacingLeft()
        {
            return false;
        }

        public override bool IsFacingRight()
        {
            return true;
        }

        public override bool IsFalling()
        {
            return true;
        }

        public override void Update(GameTime gameTime)
        {
            //Do nothing
        }
        public override bool IsGrounded()
        {
            return false;
        }
    }
}
