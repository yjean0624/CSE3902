using System;
using Project.Enemies;
using Project.Items;
using Project.GameObjects;

namespace Project.Collision
{
    public class ItemEnemyCollisionResolution : ICollisionHandler
    {
        private Item item;
        private Enemy enemy;
        public ItemEnemyCollisionResolution()
        {
        }
        public void Handle(ICollidable mover, ICollidable target, CollisionDirection.DirectionTag direction)
        {
            if (typeof(Item).IsInstanceOfType(mover) && typeof(Enemy).IsInstanceOfType(target))
            {
                item = (Item)mover;
                enemy = (Enemy)target;
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        item.Physics.yPosition = enemy.GetTopSide() - item.GetHeight();
                        item.Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        item.Physics.yPosition = enemy.GetBottomSide() + 1;
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        item.Physics.xPosition = enemy.GetLeftSide() - item.GetWidth();
                        enemy.ChangeDirection();
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        item.Physics.xPosition = enemy.GetRightSide() + 1;
                        enemy.ChangeDirection();
                        break;
                    default:
                        Console.WriteLine(Config.GetCollisionResolutionException() + GetType().ToString());
                        break;
                }
            }

        }
    }
        
}
