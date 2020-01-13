using Project.GameObjects;
using Project.Items;
using System;

namespace Project.Collision
{
    public class PlayerPushableBlockCollisionResolution : ICollisionHandler
    {
        private IMario player;
        private Item pushableBlock;
        public PlayerPushableBlockCollisionResolution()
        { }
        public void Handle(ICollidable mover, ICollidable target, CollisionDirection.DirectionTag direction)
        {
            if (typeof(IMario).IsInstanceOfType(mover) && typeof(IItem).IsInstanceOfType(target))
            {
                player = ((IMario)mover);
                pushableBlock = ((PushableBlock)target);
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        player.SetYPosition(pushableBlock.GetTopSide() - ((GameObject)player).GetHeight());
                        player.Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        player.StopJumping();
                        player.SetYPosition(pushableBlock.GetBottomSide() + 1);
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        SwapXVelocity((GameObject)player, pushableBlock);
                        player.SetXPosition(pushableBlock.GetLeftSide() - pushableBlock.GetWidth());
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        SwapXVelocity((GameObject)player, pushableBlock);
                        player.SetXPosition(pushableBlock.GetRightSide() + 1);
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
