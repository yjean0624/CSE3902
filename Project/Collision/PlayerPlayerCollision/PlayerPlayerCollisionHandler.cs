using Project.GameObjects;

namespace Project.Collision
{
    public class PlayerPlayerCollisionHandler : AbstractCollisionHandler
    {
        public PlayerPlayerCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IPlayer), typeof(IPlayer)), typeof(PlayerPlayerCollisionResolution));
        }
    }
}
