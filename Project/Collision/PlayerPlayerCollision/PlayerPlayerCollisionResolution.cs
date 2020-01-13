using Project.GameObjects;
using System;

namespace Project.Collision
{
    public class PlayerPlayerCollisionResolution : ICollisionHandler
    {
        private Mario player1;
        private Mario player2;
        public PlayerPlayerCollisionResolution()
        { }
        public void Handle(ICollidable object1, ICollidable object2, CollisionDirection.DirectionTag direction)
        {
            if (typeof(Mario).IsInstanceOfType(object1) && typeof(Mario).IsInstanceOfType(object2))
            {
                player1 = ((Mario)object1);
                player2 = ((Mario)object2);
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        player1.SetYPosition(player2.GetTopSide() - player1.GetHeight());
                        player1.Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        player1.StopJumping();
                        player1.SetYPosition(player2.GetBottomSide() + 1);
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        player1.SetXPosition(player2.GetLeftSide() - player2.GetWidth());
                        SwapXVelocity(player1, player2);
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        player1.SetXPosition(player2.GetRightSide() + 1);
                        SwapXVelocity(player1, player2);
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
