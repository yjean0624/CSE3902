using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public class RightFacingMarioState : MovementMarioState
    {
        public RightFacingMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
        }

        public override void Jump()
        {
            gameObject.SetMovementState(new RightActiveJumpingMarioState(gameObject));
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.Jump);
        }

        public override void MoveRight()
        {
            base.MoveRight();
            gameObject.SetMovementState(new RightMovingMarioState(gameObject));
        }

        public override void Crouch()
        {
            gameObject.SetMovementState(new RightCrouchingMarioState(gameObject));
        }

        public override void MoveLeft()
        {
            gameObject.SetMovementState(new LeftFacingMarioState(gameObject));
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
            //Do nothing
        }
    }
}
