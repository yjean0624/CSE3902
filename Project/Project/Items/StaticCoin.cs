using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Items
{
    public class StaticCoin : Item
    {
        public StaticCoin(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.Coin);
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            //Shouldn't move
        }
        public override void Collect()
        {
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.CollectCoin);
            base.Collect();
            GameManager.Instance.CollectCoin();
        }
    }
}
