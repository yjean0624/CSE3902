using Project.GameObjects;
using Project.Items;
using Project.Sound;

namespace Project.Collision
{
    public class PlayerSpeedBoostItemResolution : ICollisionHandler
    {
        private IMario mario;
        private SpeedBoostItem boostItem;
        public PlayerSpeedBoostItemResolution()
        {
        }
        public void Handle(ICollidable object1, ICollidable object2, CollisionDirection.DirectionTag direction)
        {

            if (typeof(IMario).IsInstanceOfType(object1) && typeof(SpeedBoostItem).IsInstanceOfType(object2))
            {
                mario = (IMario)object1;
                boostItem = (SpeedBoostItem)object2;
                //Mario should boost//
                mario.Boost();
                //boostItem disappear//
                this.boostItem.Collect();
                SoundEffectManager.Instance.PlaySoundEffect(SoundEffectManager.SoundEffectTag.GainExtraLife);
            }
        }
    }
}
