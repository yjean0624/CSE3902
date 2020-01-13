using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Levels;

using Project.Sprites;

namespace Project.Blocks
{
    public class InvisibleBlock : AbstractBlock
    {
        public InvisibleBlock(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.SolidBlock);
        }

        public override void Bump() 
        {
            SolidBlock solidBlock = new SolidBlock(Location());
            GameManager.Instance.Replace(this, solidBlock);
            solidBlock.Bump();
            solidBlock.EndBump();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Don't draw, it's invisible
        }
    }
}
