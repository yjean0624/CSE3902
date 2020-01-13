using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public class LeftFacingMarioState : MovementMarioState
    {
        public LeftFacingMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
        }

        public override void Jump()
        {
            gameObject.SetMovementState(new LeftActiveJumpingMarioState(gameObject));
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.Jump);
        }

        public override void MoveLeft()
        {
            base.MoveLeft();
            gameObject.SetMovementState(new LeftMovingMarioState(gameObject));
        }

        public override void Crouch()
        {
            gameObject.SetMovementState(new LeftCrouchingMarioState(gameObject));
        }

        public override void MoveRight()
        {
            gameObject.SetMovementState(new RightFacingMarioState(gameObject));
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
            //Do nothing
        }
    }
}
