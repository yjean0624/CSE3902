using Project.GameObjects;
using Project.Items;

namespace Project.Collision
{
    public class PlayerFlowerCollisionResolution : ICollisionHandler
    {
        private Mario mario;
        private Flower flower;
        public PlayerFlowerCollisionResolution()
        {
        }
        public void Handle(ICollidable object1, ICollidable object2, CollisionDirection.DirectionTag direction)
        {
            if (object1.GetType() == typeof(Mario) && object2.GetType() == typeof(Flower))
            {
                mario = (Mario)object1;
                flower = (Flower)object2;
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        //Mario should change to fire mario//
                        mario.CollectFlower();
                        //Flower disappear//
                        this.flower.Collect();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        //Mario should change to fire mario//
                        mario.CollectFlower();
                        //Flower disappear//
                        this.flower.Collect();
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        //Mario should change to fire mario//
                        mario.CollectFlower();
                        //Flower disappear//
                        this.flower.Collect();
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        //Mario should change to fire mario//
                        mario.CollectFlower();
                        //Flower disappear//
                        this.flower.Collect();
                        break;
                    default:
                        //no collision//
                        break;
                }
            }
        }
    }
}
