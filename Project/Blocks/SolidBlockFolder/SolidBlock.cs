using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Blocks
{
    public class SolidBlock : AbstractBlock
    {
        public SolidBlock(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.SolidBlock);
        }
    }
}
