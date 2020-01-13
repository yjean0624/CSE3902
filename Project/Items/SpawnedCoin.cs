using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.GameObjects;
using Project.Sprites;
using System;

namespace Project.Items
{
    public class SpawnedCoin : Item
    {
        public SpawnedCoin(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.Coin);
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.CollectCoin);
        }
        public override void Collect()
        {
            base.Collect();
        }
    }
}
