using Project.Enemies;
using Project.Blocks;
using System;

namespace Project.Collision
{
    public class EnemyBlockCollisionResolution : ICollisionHandler
    {
        private Enemy enemy;
        private AbstractBlock block;
        public EnemyBlockCollisionResolution()
        {
        }
        public void Handle(ICollidable enemy, ICollidable block, CollisionDirection.DirectionTag direction)
        {
            if (typeof(IEnemy).IsInstanceOfType(enemy) && typeof(IBlock).IsInstanceOfType(block))
            {
                this.enemy = (Enemy)enemy;
                this.block = (AbstractBlock)block;
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        this.enemy.Physics.yPosition = this.block.GetTopSide() - enemy.GetHeight();
                        this.enemy.Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        this.enemy.Physics.yPosition = this.block.GetBottomSide() + 1;
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        this.enemy.Physics.xPosition = this.block.GetLeftSide() - enemy.GetHeight();
                        this.enemy.ChangeDirection();
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        this.enemy.Physics.xPosition = this.block.GetRightSide() + 1;
                        this.enemy.ChangeDirection();
                        break;
                    default:
                        Console.WriteLine("Unexpected Direction Received in Collision.EnemyBlockCollisionResolution");
                        break;
                }
            }
        }
    }
}
