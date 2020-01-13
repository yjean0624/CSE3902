using Project.GameObjects;
using Project.Items;

namespace Project.Collision
{
    public class PlayerGreenMushroomCollisionResolution : ICollisionHandler
    {
        private Mario mario;
        private SpeedBoostItem greenMushroom;
        public PlayerGreenMushroomCollisionResolution()
        {
        }
        public void Handle(ICollidable object1, ICollidable object2, CollisionDirection.DirectionTag direction)
        {

            if (typeof(Mario).IsInstanceOfType(object1) && typeof(SpeedBoostItem).IsInstanceOfType(object2))
            {
                mario = (Mario)object1;
                greenMushroom = (SpeedBoostItem)object2;
                //Mario should stay unchanged//
                //GreenMushroom disappear//
                this.greenMushroom.Collect();
                mario.GainLife();
            }
        }
    }
}
