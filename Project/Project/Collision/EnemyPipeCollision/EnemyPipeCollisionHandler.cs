using Project.Enemies;
using Project.Pipes;

namespace Project.Collision
{
    public class EnemyPipeCollisionHandler:AbstractCollisionHandler
    {
        public EnemyPipeCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IEnemy), typeof(IPipe)), typeof(EnemyPipeCollisionResolution));
        }
    }
}
