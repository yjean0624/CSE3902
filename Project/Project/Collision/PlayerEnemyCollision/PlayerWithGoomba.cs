using Project.Enemies;
using Project.GameObjects;

namespace Project.Collision
{
    public class PlayerWithGoomba : ICollisionHandler
    {
        private Mario player;
        private Goomba goomba;
        public PlayerWithGoomba()
        {
        }
        public void Handle(ICollidable player, ICollidable goomba, CollisionDirection.DirectionTag direction)
        {
            if (player.GetType() == typeof(Mario) && goomba.GetType() == typeof(Goomba))
            {
                this.player = (Mario)player;
                this.goomba = (Goomba)goomba;
                if (direction == CollisionDirection.DirectionTag.Top)
                {
                    this.player.Physics.yPosition = this.goomba.GetTopSide() - this.player.GetHeight();
                    this.player.Physics.yVelocity *= -1;
                    this.goomba.Kill();
                    this.goomba.Stomp();
                }
                else if (direction == CollisionDirection.DirectionTag.Bottom || 
                    direction == CollisionDirection.DirectionTag.Left || 
                    direction == CollisionDirection.DirectionTag.Right)
                {
                    if (this.player.IsBig() || this.player.IsFire())
                    {
                        this.player.TakeDamage();
                    }
                    else if (this.player.IsSmall())
                    {
                        this.player.TakeDamage();
                    }
                    //player.IsStar()
                    else
                    {
                        this.goomba.Kill();
                        this.goomba.Fall();
                    }
                }
            }
        }
    }
}
