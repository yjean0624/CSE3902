using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public class RightCrouchingMarioState : MovementMarioState
    {
        public RightCrouchingMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
        }

        public override void Fall()
        {
            gameObject.SetMovementState(new RightFallingMarioState(gameObject));
        }

        public override void Stand()
        {
            gameObject.SetMovementState(new RightFacingMarioState(gameObject));
        }
        public override void MoveRight()
        {
            base.MoveRight();
        }
        public override bool IsFacingLeft()
        {
            return false;
        }

        public override bool IsFacingRight()
        {
            return true;
        }

        public override bool IsCrouching()
        {
            return true;
        }

        public override void Update(GameTime gameTime)
        {
            //Do nothing
        }
    }
}
