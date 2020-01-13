using Project.GameObjects;
using Project.Pipes;

namespace Project.Collision
{
    public class PlayerPipeCollisionHandler : AbstractCollisionHandler
    {
        public PlayerPipeCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IPlayer), typeof(AbstractPipe)), typeof(PlayerPipeCollisionResolution));
        }
    }
}
