using Project.Enemies;
using Project.GameObjects;
using Project.Sound;

namespace Project.Collision
{
    public class PlayerWithKoopaShell: ICollisionHandler
    {
        private Mario player;
        private KoopaShell koopaShell;
        private ReversedKoopaShell reversedKoopaShell;
        public PlayerWithKoopaShell()
        {
        }

        public void Handle(ICollidable player, ICollidable koopaShell, CollisionDirection.DirectionTag direction)
        {
            if (typeof(Mario).IsInstanceOfType(player) && typeof(KoopaShell).IsInstanceOfType(koopaShell))
            {
                this.player = (Mario)player;
                this.koopaShell = (KoopaShell)koopaShell;
                reversedKoopaShell = new ReversedKoopaShell(this.koopaShell.Location());
                //when mario is star
                if (!this.player.IsBig() && !this.player.IsFire() && !this.player.IsSmall())
                {
                    this.player.Boost();
                    GameManager.Instance.Replace(this.koopaShell, reversedKoopaShell);
                }
                else
                {
                    if (direction == CollisionDirection.DirectionTag.Left)
                    {
                        this.player.TakeDamage();
                    }
                    else if (direction == CollisionDirection.DirectionTag.Right)
                    {
                        this.player.TakeDamage();
                    }
                    if (direction == CollisionDirection.DirectionTag.Top)
                    {
                        this.player.Boost();
                        this.player.Physics.yPosition = this.koopaShell.GetTopSide() - this.player.GetHeight();
                        this.player.Physics.yVelocity *= -1;
                    }
                    SoundEffectManager.Instance.PlaySoundEffect(SoundEffectManager.SoundEffectTag.Kick);
                }
            }
            if (typeof(StarMario).IsInstanceOfType(player))
            {
                ((StarMario)player).Boost();
                reversedKoopaShell = new ReversedKoopaShell(((KoopaShell)koopaShell).Location());
                GameManager.Instance.Replace((KoopaShell)koopaShell, reversedKoopaShell);
            }
            
        }
    }
}
