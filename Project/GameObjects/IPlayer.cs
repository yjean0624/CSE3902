namespace Project.GameObjects
{
    public interface IPlayer : IGameObject
    {
        void MoveLeft();
        void MoveRight();
        void Jump();
        void Crouch();
        void StopJumping();
        void Idle();
        void Stand();
        void Fall();
        void Ground();
        void TakeDamage();
    }
}
