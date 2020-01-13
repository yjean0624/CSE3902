using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public interface IMovementState
    {
        void MoveLeft();

        void MoveRight();

        void Jump();

        void Crouch();

        void Ground();

        void Idle();

        void Fall();

        void Stand();

        void StopJumping();

        bool IsRunning();

        bool IsJumping();

        bool IsCrouching();

        bool IsGrounded();

        bool IsFalling();

        bool IsFacingLeft();

        bool IsFacingRight();
        void Update(GameTime gameTime);
    }
}
