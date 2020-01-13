using Project.Enemies;
using Project.GameObjects;

namespace Project.Collision
{
    public class EnemyFireballCollisionHandler : AbstractCollisionHandler
    {
        public EnemyFireballCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IEnemy), typeof(IProjectile)), typeof(EnemyFireballCollisionResolution));
        }
    }
}
