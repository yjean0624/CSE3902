using Project.Enemies;

namespace Project.Collision.EnemyEnemyCollision
{
    public class EnemyEnemyCollisionHandler: AbstractCollisionHandler
    {
        public EnemyEnemyCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IEnemy), typeof(IEnemy)), typeof(EnemyEnemyCollisionResolution));
        }
    }
}
