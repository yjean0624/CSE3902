using System;
using Project.Items;
using Project.Pipes;

namespace Project.Collision
{
    public class ItemPipeCollisionResolution : ICollisionHandler
    {
        private Item item;
        private IPipe pipe;
        public ItemPipeCollisionResolution()
        {
        }
        public void Handle(ICollidable object1, ICollidable object2, CollisionDirection.DirectionTag direction)
        {
            if (typeof(Item).IsInstanceOfType(object1) && typeof(IPipe).IsInstanceOfType(object2))
            {
                item = (Item)object1;
                pipe = (AbstractPipe)object2;
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        item.Physics.yPosition = pipe.GetTopSide() - item.GetHeight();
                        item.Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        item.Physics.yPosition = pipe.GetBottomSide() + 1;
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        item.Physics.xPosition = pipe.GetLeftSide() - item.GetWidth();
                        item.ChangeDirection();
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        item.Physics.xPosition = pipe.GetRightSide() + 1;
                        item.ChangeDirection();
                        break;
                    default:
                        Console.WriteLine(Config.GetCollisionResolutionException() + GetType().ToString());
                        break;
                }
            }
        }
    }
}
