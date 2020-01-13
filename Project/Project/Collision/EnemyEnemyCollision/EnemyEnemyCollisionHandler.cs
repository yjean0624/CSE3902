using Project.Enemies;

namespace Project.Collision.EnemyEnemyCollision
{
    public class EnemyEnemyCollisionHandler: AbstractCollisionHandler
    {
        public EnemyEnemyCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(Goomba), typeof(Goomba)), typeof(EnemyEnemyCollisionResolution));
            collisionResolutionMap.Add((typeof(Koopa), typeof(Koopa)), typeof(EnemyEnemyCollisionResolution));
            collisionResolutionMap.Add((typeof(Goomba), typeof(Koopa)), typeof(EnemyEnemyCollisionResolution));
            collisionResolutionMap.Add((typeof(KoopaShell), typeof(IEnemy)), typeof(KoopaShellEnemyCollisionResolution));
        }
    }
}
