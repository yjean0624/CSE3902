using Project.Enemies;
using Project.Blocks;

namespace Project.Collision
{
    public class EnemyBlockCollisionHandler : AbstractCollisionHandler
    {
        public EnemyBlockCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IEnemy), typeof(IBlock)), typeof(EnemyBlockCollisionResolution));
        }
    }
}
