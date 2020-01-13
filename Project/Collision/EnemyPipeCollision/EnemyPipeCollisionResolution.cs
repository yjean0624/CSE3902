using Project.Enemies;
using Project.Pipes;
using System;

namespace Project.Collision
{
    public class EnemyPipeCollisionResolution: ICollisionHandler
    {
        private Enemy enemy;
        private AbstractPipe pipe;
        public EnemyPipeCollisionResolution()
        {
        }
        public void Handle(ICollidable enemy, ICollidable pipe, CollisionDirection.DirectionTag direction)
        {
            if (typeof(IEnemy).IsInstanceOfType(enemy) && typeof(IPipe).IsInstanceOfType(pipe))
            {
                this.enemy = (Enemy)enemy;
                this.pipe = (AbstractPipe)pipe;
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        this.enemy.Physics.yPosition = this.pipe.GetTopSide() - enemy.GetHeight();
                        this.enemy.Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        this.enemy.Physics.xPosition = this.pipe.GetLeftSide() - enemy.GetWidth();
                        this.enemy.ChangeDirection();
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        this.enemy.Physics.xPosition = this.pipe.GetRightSide() + 1;
                        this.enemy.ChangeDirection();
                        break;
                    default:
                        Console.WriteLine(Config.GetCollisionResolutionException() + GetType().ToString());
                        break;
                }
            }
        }
    }
}
