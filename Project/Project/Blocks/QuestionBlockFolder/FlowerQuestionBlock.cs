using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Blocks
{
    public class FlowerQuestionBlock : AbstractQuestionBlock
    {
        public FlowerQuestionBlock(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.QuestionBlock);
            itemState = new FlowerState(this);
        }
        public override void Bump()
        {
            base.Bump();
            itemState.ReleaseItem();
        }
    }
}
