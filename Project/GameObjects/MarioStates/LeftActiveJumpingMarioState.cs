using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    class LeftActiveJumpingMarioState : MovementMarioState
    {
        private static float transitionTimeInSeconds = Config.GetMaxTimeInActiveJumpingInSeconds();
        private float totalSecondsInTransition;
        public LeftActiveJumpingMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
            totalSecondsInTransition = 0.0f;
            gameObject.Physics.yVelocity += Config.GetPlayerInitialJumpPower();
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.Jump);
        }

        public override void Ground()
        {
            gameObject.SetMovementState(new LeftFacingMarioState(gameObject));
        }

        public override void StopJumping()
        {
            gameObject.SetMovementState(new LeftPassiveJumpingMarioState(gameObject));
        }
        public override void Jump()
        {
            gameObject.Physics.yVelocity += Config.GetPlayerPassiveJumpPower();
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

        public override bool IsGrounded()
        {
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            totalSecondsInTransition += ((float)gameTime.ElapsedGameTime.Milliseconds) / 1000;
            if (totalSecondsInTransition >= transitionTimeInSeconds)
            {
                gameObject.SetMovementState(new LeftPassiveJumpingMarioState(gameObject));
            }
        }
    }
}
