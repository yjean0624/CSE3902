using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;

namespace Project.Blocks
{
    public class GroundBlock : AbstractBlock
    {
        public GroundBlock(Vector2 location, ISprite sprite) : base(location)
        {
            this.sprite = sprite;
        }
    }
}
