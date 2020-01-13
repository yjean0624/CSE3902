using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public class LeftPassiveJumpingMarioState : MovementMarioState
    {
        public LeftPassiveJumpingMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
        }

        public override bool IsFacingLeft()
        {
            return true;
        }

        public override bool IsFacingRight()
        {
            return false;
        }

        public override bool IsJumping()
        {
            return true;
        }

        public override void Ground()
        {
            gameObject.SetMovementState(new LeftFacingMarioState(gameObject));
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
