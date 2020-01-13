using Project.GameObjects;
using Project.Items;

namespace Project.Collision
{
    public class PlayerCoinCollisionResolution : ICollisionHandler
    {
        private StaticCoin coin;
        public PlayerCoinCollisionResolution()
        {
        }
        public void Handle(ICollidable object1, ICollidable object2, CollisionDirection.DirectionTag direction)
        {
            if (typeof(IMario).IsInstanceOfType(object1) && typeof(StaticCoin).IsInstanceOfType(object2))
            {
                coin = (StaticCoin)object2;
                coin.Collect();
            }
        }
    }
}
