using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public class LeftMovingMarioState : MovementMarioState
    {
        public LeftMovingMarioState(Mario gameObject) : base(gameObject)
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

        public override bool IsRunning()
        {
            return true;
        }

        public override void Idle()
        {
            gameObject.SetMovementState(new LeftFacingMarioState(gameObject));
        }

        public override void Jump()
        {
            gameObject.SetMovementState(new LeftActiveJumpingMarioState(gameObject));
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.Jump);
        }

        public override void Fall()
        {
            gameObject.SetMovementState(new LeftFallingMarioState(gameObject));
        }

        public override void MoveRight()
        {
            gameObject.SetMovementState(new LeftToRightTransitionMarioState(gameObject));
        }

        public override void Update(GameTime gameTime)
        {
            //Do nothing
        }
    }
}
