using Microsoft.Xna.Framework;

namespace Project.Enemies.EnemyStates
{
    public interface IGoombaState
    {
        void ChangeDirection();
        void BeStomped();
        void BeFlipped();
        void Update(GameTime gameTime);
    }
}
