using Project.GameObjects;
using Project.Items;
using Project.Sound;

namespace Project.Collision
{
    public class PlayerBrownMushroomCollisionResolution : ICollisionHandler
    {
        private IMario player;
        private BrownMushroom brownMushroom;
        public PlayerBrownMushroomCollisionResolution()
        {
        }
        public void Handle(ICollidable object1, ICollidable object2, CollisionDirection.DirectionTag direction )
        {
            if (typeof(IMario).IsInstanceOfType(object1) && typeof(BrownMushroom).IsInstanceOfType(object2))
            {
                this.player = (IMario)object1;
                this.brownMushroom = (BrownMushroom)object2;
                //Mario should become big//
                player.CollectBrownMushroom();
                //BrownMushroom disappear//
                this.brownMushroom.Collect();
            }
        }
    }
}
