using Project.Enemies;
using Project.GameObjects;
using static Project.Enemies.Enemy;

namespace Project.Collision
{
    public class PlayerWithKoopa : ICollisionHandler
    {
        private Mario player;
        private Koopa koopa;
        private ReversedKoopaShell reversedKoopaShell;
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
                reversedKoopaShell = new ReversedKoopaShell(this.koopa.Location());
                if (this.koopa.Physics.xVelocity == 0)
                {
                    if (direction == CollisionDirection.DirectionTag.Left || 
                        (direction == CollisionDirection.DirectionTag.Top && 
                        this.koopa.Physics.xPosition > this.player.Physics.xPosition))
                    {
                        this.koopa.Physics.xPosition += Config.GetKoopaToKoopaShellFaultTolerancePosition();
                        this.koopa.Physics.yPosition += Config.GetKoopaToKoopaShellFaultTolerancePosition();
                        koopaShell = new KoopaShell(this.koopa.Location());
                        this.player.Boost();
                        GameManager.Instance.Replace(this.koopa, koopaShell);
                        koopaShell.MoveRight();
                    }
                    else if(direction == CollisionDirection.DirectionTag.Right || 
                        (direction == CollisionDirection.DirectionTag.Top && 
                        this.koopa.Physics.xPosition <= this.player.Physics.xPosition))
                    {
                        this.koopa.Physics.xPosition -= Config.GetKoopaToKoopaShellFaultTolerancePosition();
                        this.koopa.Physics.yPosition += Config.GetKoopaToKoopaShellFaultTolerancePosition();
                        koopaShell = new KoopaShell(this.koopa.Location());
                        this.player.Boost();
                        GameManager.Instance.Replace(this.koopa, koopaShell);
                        koopaShell.MoveLeft();
                    }
                }
                else {
                    if (direction == CollisionDirection.DirectionTag.Top)
                    {
                        this.player.Physics.yPosition = this.koopa.GetTopSide() - this.player.GetHeight();
                        this.player.Physics.yVelocity *= -1;
                        this.koopa.BecomeStaticKS();
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
                    }
                }
            }
            if (typeof(StarMario).IsInstanceOfType(player) && typeof(Koopa).IsInstanceOfType(koopa))
            {
                ((StarMario)player).Boost();
                reversedKoopaShell = new ReversedKoopaShell(((Koopa)koopa).Location());
                GameManager.Instance.Replace((Koopa)koopa, reversedKoopaShell);
            }
        }
    }
}
