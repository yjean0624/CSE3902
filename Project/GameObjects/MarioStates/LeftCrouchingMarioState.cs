using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public class LeftCrouchingMarioState : MovementMarioState
    {
        public LeftCrouchingMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
        }

        public override void Fall()
        {
            gameObject.SetMovementState(new LeftFallingMarioState(gameObject));
        }

        public override void Stand()
        {
            gameObject.SetMovementState(new LeftFacingMarioState(gameObject));
        }
        public override void MoveLeft()
        {
            //do nothing
        }

        public override bool IsFacingLeft()
        {
            return true;
        }

        public override bool IsFacingRight()
        {
            return false;
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
