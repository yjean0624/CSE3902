using Project.Enemies;
using Project.GameObjects;

namespace Project.Collision
{
    public class PlayerWithKoopa : ICollisionHandler
    {
        private Mario player;
        private Koopa koopa;
        private KoopaShell koopaShell;
        public PlayerWithKoopa()
        {
        }

        public void Handle(ICollidable player, ICollidable koopa, CollisionDirection.DirectionTag direction)
        {
            if (player.GetType() == typeof(Mario) && koopa.GetType() == typeof(Koopa))
            {
                this.player = (Mario)player;
                this.koopa = (Koopa)koopa;
                this.koopaShell = new KoopaShell(this.koopa.Location());
                if (direction == CollisionDirection.DirectionTag.Top)
                {
                    this.player.Physics.yPosition = this.koopa.GetTopSide() - this.player.GetHeight();
                    this.player.Physics.yVelocity *= -1;
                    GameManager.Instance.Replace(this.koopa, koopaShell);
                    koopaShell.Still();
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
                    else
                    {
                        GameManager.Instance.Replace(this.koopa, koopaShell);
                        koopaShell.Fall();
                    }
                    
                }
            }
        }
    }
}
