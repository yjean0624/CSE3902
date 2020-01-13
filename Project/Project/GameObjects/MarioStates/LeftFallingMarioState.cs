using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    class LeftFallingMarioState : MovementMarioState
    {
        public LeftFallingMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
        }
        public override void Ground()
        {
            gameObject.SetMovementState(new LeftFacingMarioState(gameObject));
        }
        public override bool IsFacingLeft()
        {
            return true;
        }

        public override bool IsFacingRight()
        {
            return false;
        }

        public override bool IsFalling()
        {
            return true;
        }

        public override void Update(GameTime gameTime)
        {
            //Do nothing
        }
    }
}
