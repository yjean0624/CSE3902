using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    class LeftToRightTransitionMarioState : MovementMarioState
    {
        private static float transitionTimeInSeconds = Config.GetDirectionTransitionTimeInSeconds();
        private float totalSecondsInTransition;
        public LeftToRightTransitionMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
            totalSecondsInTransition = 0.0f;
        }
        public override void MoveLeft()
        {
            base.MoveLeft();
            gameObject.SetMovementState(new LeftMovingMarioState(gameObject));
        }
        public override bool IsFacingLeft()
        {
            return true;
        }

        public override bool IsFacingRight()
        {
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            totalSecondsInTransition += ((float)gameTime.ElapsedGameTime.Milliseconds) / 1000;
            if (totalSecondsInTransition >= transitionTimeInSeconds)
            {
                gameObject.SetMovementState(new RightMovingMarioState(gameObject));
            }
        }
    }
}
