using Microsoft.Xna.Framework;
using Project.Levels;
using Project.Sound;

using Project.Sprites;

namespace Project.Blocks
{
    public class UndergroundBrickBlock : NormalBrickBlock
    {
        public UndergroundBrickBlock(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.UndergroundBrickBlock);
        }
    }
}
