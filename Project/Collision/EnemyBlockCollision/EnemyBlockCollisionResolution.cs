using Project.Enemies;
using Project.Blocks;
using System;

namespace Project.Collision
{
    public class EnemyBlockCollisionResolution : ICollisionHandler
    {
        public EnemyBlockCollisionResolution()
        {
        }
        public void Handle(ICollidable enemy, ICollidable block, CollisionDirection.DirectionTag direction)
        {
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        ((Enemy)enemy).Physics.yPosition = block.GetTopSide() - enemy.GetHeight();
                        ((Enemy)enemy).Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        ((Enemy)enemy).Physics.yPosition = block.GetBottomSide() + 1;
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        ((Enemy)enemy).Physics.xPosition = block.GetLeftSide() - enemy.GetHeight();
                        ((Enemy)enemy).ChangeDirection();
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        ((Enemy)enemy).Physics.xPosition = block.GetRightSide() + 1;
                        ((Enemy)enemy).ChangeDirection();
                        break;
                    default:
                        Console.WriteLine(Config.GetCollisionResolutionException() + GetType().ToString());
                        break;
                }
        }
    }
}
