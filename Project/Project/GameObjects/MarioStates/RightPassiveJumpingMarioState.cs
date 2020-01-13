using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public class RightPassiveJumpingMarioState : MovementMarioState
    {
        public RightPassiveJumpingMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
        }

        public override bool IsFacingLeft()
        {
            return false;
        }

        public override bool IsFacingRight()
        {
            return true;
        }

        public override bool IsJumping()
        {
            return true;
        }

        public override void Ground()
        {
            base.Ground();
            gameObject.SetMovementState(new RightFacingMarioState(gameObject));
        }

        public override void Update(GameTime gameTime)
        {
            //Do nothing
        }
    }
}
