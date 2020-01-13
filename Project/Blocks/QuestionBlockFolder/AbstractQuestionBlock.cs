using Microsoft.Xna.Framework;
using Project.Levels;
using Project.Sprites;

namespace Project.Blocks
{
    public abstract class AbstractQuestionBlock : AbstractBlock
    {
        public AbstractQuestionBlock(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.QuestionBlock);
        }
        public override void Bump()
        {
            SolidBlock solidBlock = new SolidBlock(Location());
            bumpState.Bump();
            solidBlock.Bump();
            GameManager.Instance.Replace(this, solidBlock);
        }
    }
}
