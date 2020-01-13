using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Blocks
{
    public class StairBlock : AbstractBlock
    { 
        public StairBlock(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.StairBlock);
        }
    }
}
