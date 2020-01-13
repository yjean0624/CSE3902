
using Project.Enemies;

namespace Project.Collision.EnemyEnemyCollision
{
    public class KoopaShellEnemyCollisionResolution: ICollisionHandler
    {
        private Enemy koopaShell;
        private Enemy enemy;
        public KoopaShellEnemyCollisionResolution()
        {
        }

        public void Handle(ICollidable koopaShell, ICollidable enemy, CollisionDirection.DirectionTag direction)
        {
            this.koopaShell = (KoopaShell)koopaShell;
            this.enemy = (Enemy)enemy;
            if(direction == CollisionDirection.DirectionTag.Left 
                || direction == CollisionDirection.DirectionTag.Right)
            {
                this.enemy.Fall();
            }
        }

    }
}
