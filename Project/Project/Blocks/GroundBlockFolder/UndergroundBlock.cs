using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;

namespace Project.Blocks
{
    public class UndergroundBlock : GroundBlock
    {
        public UndergroundBlock(Vector2 location, ISprite sprite) : base(location, sprite)
        {
            this.sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.UndergroundBlock1x1);
        }
    }
}
