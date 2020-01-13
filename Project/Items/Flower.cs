using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Items
{
    class Flower : Item
    {
        public Flower(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.Flower);
        }
        public override void Collect()
        {
            base.Collect();
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.PowerUp);
        }
    }
}
