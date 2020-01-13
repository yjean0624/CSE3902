

using Microsoft.Xna.Framework;

namespace Project.Enemies.EnemyStates.KoopaState
{
    public class RightMovingKoopaState: IKoopaState
    {
        private Koopa koopa;
        public RightMovingKoopaState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void Update(GameTime gameTime)
        {
            this.koopa.Physics.xPosition += 0.5f;
        }
    }
}
