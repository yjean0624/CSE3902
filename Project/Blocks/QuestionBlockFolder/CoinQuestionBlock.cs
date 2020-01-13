using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Blocks
{
    public class CoinQuestionBlock : AbstractQuestionBlock
    {
        public CoinQuestionBlock(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.QuestionBlock);
            itemState = new CoinState(this);
        }
        public override void Bump()
        {
            base.Bump();
            itemState.ReleaseItem();
        }
    }
}
