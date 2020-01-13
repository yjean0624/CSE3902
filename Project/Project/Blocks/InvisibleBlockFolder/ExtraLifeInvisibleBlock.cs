using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Blocks
{
    public class ExtraLifeInvisibleBlock : InvisibleBlock
    {
        public ExtraLifeInvisibleBlock(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.InvisibleBlock);
            itemState = new GreenMushroomState(this);
        }
        public override void Bump()
        {
            base.Bump();
            itemState.ReleaseItem();
        }
    }
}
