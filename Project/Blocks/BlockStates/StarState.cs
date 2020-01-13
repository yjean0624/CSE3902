using Project.Levels;
using Project.Items;
using Microsoft.Xna.Framework;

namespace Project.Blocks
{
    public class StarState : AbstractItemState
    {
        public StarState(AbstractBlock block) : base(block)
        {
            this.block = block;
        }
        public override void ReleaseItem()
        {
            Star star = new Star(new Vector2(block.Location().X, block.Location().Y - block.GetHitBox().Height));
            GameManager.Instance.AddToCollidables(star);
            star.Physics.xVelocity = Config.GetItemMovementSpeed();
            block.itemState = new EmptyItemState(block);
        }
    }
}
