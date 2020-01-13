using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    class RightToLeftTransitionMarioState : MovementMarioState
    {
        private static float transitionTimeInSeconds = Config.GetDirectionTransitionTimeInSeconds();
        private float totalSecondsInTransition;
        public RightToLeftTransitionMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
            totalSecondsInTransition = 0.0f;
        }
        public override void MoveRight()
        {
            base.MoveRight();
            gameObject.SetMovementState(new RightMovingMarioState(gameObject));
        }
        public override bool IsFacingLeft()
        {
            return false;
        }

        public override bool IsFacingRight()
        {
            return true;
        }

        public override void Update(GameTime gameTime)
        {
            totalSecondsInTransition += ((float)gameTime.ElapsedGameTime.Milliseconds) / 1000;
            if (totalSecondsInTransition >= transitionTimeInSeconds)
            {
                gameObject.SetMovementState(new LeftMovingMarioState(gameObject));
            }
        }
    }
}
