using Project.Enemies;
using System;

namespace Project.Collision.EnemyEnemyCollision
{
    public class EnemyEnemyCollisionResolution: ICollisionHandler
    {
        private Enemy enemy1;
        private Enemy enemy2;
        public EnemyEnemyCollisionResolution()
        {
        }
        public void Handle(ICollidable enemy1, ICollidable enemy2, CollisionDirection.DirectionTag direction)
        {
            if (typeof(IEnemy).IsInstanceOfType(enemy1) 
                && typeof(IEnemy).IsInstanceOfType(enemy2))
            {
                this.enemy1 = (Enemy)enemy1;
                this.enemy2 = (Enemy)enemy2;
                if (this.enemy2.Physics.xVelocity > Config.GetMovingShellDecidingSpeed() 
                    || this.enemy2.Physics.xVelocity < -Config.GetMovingShellDecidingSpeed())
                {
                    this.enemy1.Fall();
                }
                else
                {
                    switch (direction)
                    {
                        case CollisionDirection.DirectionTag.Top:
                            this.enemy1.Physics.yPosition = this.enemy2.GetTopSide() - 1;
                            break;
                        case CollisionDirection.DirectionTag.Bottom:
                            this.enemy1.Physics.yPosition = this.enemy2.GetBottomSide() + 1;
                            this.enemy2.Physics.yPosition = this.enemy1.GetTopSide() - 1;
                            break;
                        case CollisionDirection.DirectionTag.Left:
                            this.enemy1.Physics.xPosition -= 1;
                            this.enemy2.Physics.xPosition += 1;
                            this.enemy1.ChangeDirection();
                            this.enemy2.ChangeDirection();
                            break;
                        case CollisionDirection.DirectionTag.Right:
                            this.enemy2.Physics.xPosition -= 1;
                            this.enemy1.Physics.xPosition += 1;
                            this.enemy1.ChangeDirection();
                            this.enemy2.ChangeDirection();
                            break;
                        default:
                            Console.WriteLine(Config.GetCollisionResolutionException() + GetType().ToString());
                            break;
                    }
                }
                
            }
        }
    }
}
