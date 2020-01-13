using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Blocks
{
    public class PowerUpInvisibleBlock : InvisibleBlock
    {
        public PowerUpInvisibleBlock(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.InvisibleBlock);
            itemState = new BrownMushroomState(this);
        }
        public override void Bump()
        {
            base.Bump();
            itemState.ReleaseItem();
        }
    }
}
