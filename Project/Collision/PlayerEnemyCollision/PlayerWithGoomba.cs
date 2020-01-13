using Project.Enemies;
using Project.GameObjects;

namespace Project.Collision
{
    public class PlayerWithGoomba : ICollisionHandler
    {
        private Mario player;
        private Goomba goomba;
        private StompedGoomba stompedGoomba;
        private ReversedGoomba reversedGoomba;
        public PlayerWithGoomba()
        {
        }
        public void Handle(ICollidable player, ICollidable goomba, CollisionDirection.DirectionTag direction)
        {
            if (typeof(Mario).IsInstanceOfType(player) && typeof(Goomba).IsInstanceOfType(goomba))
            {
                this.player = (Mario)player;
                this.goomba = (Goomba)goomba;
                this.stompedGoomba = new StompedGoomba(this.goomba.Location());
                this.reversedGoomba = new ReversedGoomba(this.goomba.Location());
                if (direction == CollisionDirection.DirectionTag.Top)
                {
                    this.player.Physics.yPosition = this.goomba.GetTopSide() - this.player.GetHeight();
                    this.player.Physics.yVelocity *= -1;
                    this.player.Boost();
                    GameManager.Instance.Replace(this.goomba, stompedGoomba);
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
                }
            }
            if (typeof(StarMario).IsInstanceOfType(player)&& typeof(Goomba).IsInstanceOfType(goomba))
            {
                reversedGoomba = new ReversedGoomba(((Goomba)goomba).Location());
                ((StarMario)player).Boost();
                GameManager.Instance.Replace((Goomba)goomba, reversedGoomba);
            }
        }
    }
}
