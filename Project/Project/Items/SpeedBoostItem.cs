using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Items
{
    class SpeedBoostItem : Item
    {
        public SpeedBoostItem(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.SpeedBoostItem);
            Physics.xVelocity = 10.0f;
        }
        public override void Collect()
        {
            base.Collect();
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.GainExtraLife);
        }
    }
}
