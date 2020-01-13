using System;
using Project.Items;
using Project.GameObjects;

namespace Project.Collision
{
    public class PushableBlockPushableBlockCollisionResolution : ICollisionHandler
    {
        private PushableBlock item1;
        private PushableBlock item2;
        public PushableBlockPushableBlockCollisionResolution()
        { }
        public void Handle(ICollidable mover, ICollidable target, CollisionDirection.DirectionTag direction)
        {
            if (typeof(PushableBlock).IsInstanceOfType(mover) && typeof(PushableBlock).IsInstanceOfType(target))
            {
                item1 = (PushableBlock)mover;
                item2 = (PushableBlock)target;
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        item1.Physics.yPosition = item2.GetTopSide() - item1.GetHeight();
                        item1.Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        item1.Physics.yPosition = item2.GetBottomSide() + 1;
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        SwapXVelocity(item1, item2);
                        item1.Physics.xPosition = item2.GetLeftSide() - item1.GetWidth();
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        SwapXVelocity(item1, item2);
                        item1.Physics.xPosition = item2.GetRightSide() + 1;
                        break;
                    default:
                        Console.WriteLine(Config.GetCollisionResolutionException() + GetType().ToString());
                        break;
                }
            }
        }
        private void SwapXVelocity(GameObject mover, GameObject target)
        {
            float temp;
            temp = mover.Physics.xVelocity;
            mover.Physics.xVelocity = target.Physics.xVelocity;
            target.Physics.xVelocity = temp;
        }
    }
}
