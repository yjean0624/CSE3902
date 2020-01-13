using Microsoft.Xna.Framework;
using System;


namespace Project.Enemies.EnemyStates.KoopaState
{
    public class LeftMovingKoopaState : IKoopaState
    {
        private Koopa koopa;
        public LeftMovingKoopaState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void Update(GameTime gameTime)
        {
            this.koopa.Physics.yPosition -= 0.5f;
        }
    }
}
