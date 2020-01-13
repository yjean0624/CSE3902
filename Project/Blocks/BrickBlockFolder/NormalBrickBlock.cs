using Microsoft.Xna.Framework;
using Project.Levels;
using Project.Sound;

using Project.Sprites;

namespace Project.Blocks
{
    public class NormalBrickBlock : AbstractBlock
    {
        public NormalBrickBlock(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.SolidBrickBlock);
        }
        public virtual void Break()
        {
            GameManager.Instance.Remove(this);
            SoundEffectManager.Instance.PlaySoundEffect(SoundEffectManager.SoundEffectTag.BreakBlock);
        }
    }
}
