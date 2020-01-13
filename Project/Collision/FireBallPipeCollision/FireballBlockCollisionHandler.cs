using Project.GameObjects;
using Project.Pipes;

namespace Project.Collision
{
    public class FireballPipeCollisionHandler : AbstractCollisionHandler
    {
        public FireballPipeCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IProjectile), typeof(IPipe)), typeof(FireballPipeCollisionResolution));
        }
    }
}
