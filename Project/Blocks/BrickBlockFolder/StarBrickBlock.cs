using Project.Sprites;
using Microsoft.Xna.Framework;
using Project.Levels;

namespace Project.Blocks
{
    public class StarBrickBlock : NormalBrickBlock
    {
        public StarBrickBlock(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.SolidBrickBlock);
            itemState = new StarState(this);
        }
        public override void Bump()
        {
            base.Bump();
            itemState.ReleaseItem();
            SolidBlock solidBlock = new SolidBlock(Location());
            bumpState.Bump();
            solidBlock.Bump();
            GameManager.Instance.Replace(this, solidBlock);
        }
    }
}
