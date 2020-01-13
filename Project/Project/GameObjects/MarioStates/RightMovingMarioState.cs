using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public class RightMovingMarioState : MovementMarioState
    {
        public RightMovingMarioState(Mario gameObject) : base(gameObject)
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

        public override bool IsRunning()
        {
            return true;
        }

        public override void Idle()
        {
            gameObject.SetMovementState(new RightFacingMarioState(gameObject));
        }

        public override void Jump()
        {
            gameObject.SetMovementState(new RightActiveJumpingMarioState(gameObject));
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.Jump);
        }

        public override void Fall()
        {
            gameObject.SetMovementState(new RightFallingMarioState(gameObject));
        }

        public override void MoveLeft()
        {
            gameObject.SetMovementState(new RightToLeftTransitionMarioState(gameObject));
        }

        public override void Update(GameTime gameTime)
        {
            //Do nothing
        }
    }
}
