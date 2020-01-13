using Project.GameObjects;

namespace Project.Collision
{
    public class PlayerFlagpoleCollisionHandler : AbstractCollisionHandler
    {
        public PlayerFlagpoleCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IPlayer), typeof(IFlagpole)), typeof(PlayerFlagpoleCollisionResolution));
        }
    }
}
