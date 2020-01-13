using Project.Enemies;
using Project.GameObjects;
using Project.Sound;

namespace Project.Collision
{
    public class PlayerWithKoopaShell: ICollisionHandler
    {
        private Mario player;
        private KoopaShell koopaShell;
        public PlayerWithKoopaShell()
        {
        }

        public void Handle(ICollidable player, ICollidable koopaShell, CollisionDirection.DirectionTag direction)
        {
            if (typeof(Mario).IsInstanceOfType(player) && typeof(KoopaShell).IsInstanceOfType(koopaShell))
            {
                this.player = (Mario)player;
                this.koopaShell = (KoopaShell)koopaShell;
                if (direction == CollisionDirection.DirectionTag.Left)
                {
                    this.koopaShell.Kick();
                }
                else if (direction == CollisionDirection.DirectionTag.Right)
                {
                    this.koopaShell.Kick();
                    this.koopaShell.ChangeDirection();
                }
                else if (direction == CollisionDirection.DirectionTag.Top)
                {
                    this.player.Physics.yPosition = this.koopaShell.GetTopSide() - this.player.GetHeight();
                    this.player.Physics.yVelocity *= -1;
                }
                SoundEffectManager.Instance.PlaySoundEffect(SoundEffectManager.SoundEffectTag.Kick);
            }
        }
    }
}
