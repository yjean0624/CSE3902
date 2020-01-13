using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    class RightActiveJumpingMarioState : MovementMarioState
    {
        private static float transitionTimeInSeconds = Config.GetMaxTimeInActiveJumpingInSeconds();
        private float totalSecondsInTransition;
        public RightActiveJumpingMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
            totalSecondsInTransition = 0.0f;
            gameObject.Physics.yVelocity += Config.GetPlayerInitialJumpPower();
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.Jump);
        }

        public override void Ground()
        {
            gameObject.SetMovementState(new RightFacingMarioState(gameObject));
        }

        public override void StopJumping()
        {
            gameObject.SetMovementState(new RightPassiveJumpingMarioState(gameObject));
        }
        public override void Jump()
        {
            gameObject.Physics.yVelocity += Config.GetPlayerPassiveJumpPower();
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

        public override void Update(GameTime gameTime)
        {
            totalSecondsInTransition += ((float)gameTime.ElapsedGameTime.Milliseconds) / 1000;
            if (totalSecondsInTransition >= transitionTimeInSeconds)
            {
                gameObject.SetMovementState(new RightPassiveJumpingMarioState(gameObject));
            }
        }
        public override bool IsGrounded()
        {
            return false;
        }
    }
}
