using Microsoft.Xna.Framework;

namespace Project.Enemies.EnemyStates.KoopaShellState
{
    public interface IKoopaShellState
    {
        void ChangeDirection();
        void Kick();
        void BeFlipped();
        void Update(GameTime gameTime);
    }
}
