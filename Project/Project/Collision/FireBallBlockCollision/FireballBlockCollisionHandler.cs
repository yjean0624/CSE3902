using Project.GameObjects;
using Project.Blocks;

namespace Project.Collision
{
    public class FireballBlockCollisionHandler : AbstractCollisionHandler
    {
        public FireballBlockCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IProjectile), typeof(IBlock)), typeof(FireballBlockCollisionResolution));
        }
    }
}
