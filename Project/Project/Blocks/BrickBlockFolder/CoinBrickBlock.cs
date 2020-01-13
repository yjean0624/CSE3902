using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Blocks
{
    public class CoinBrickBlock : NormalBrickBlock
    {
        public CoinBrickBlock(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.SolidBrickBlock);
            itemState = new CoinState(this);
        }
        public override void Bump()
        {
            base.Bump();
            itemState.ReleaseItem();
        }
    }
}
