using Project.Items;
using Microsoft.Xna.Framework;

namespace Project.Blocks
{
    public class SpeedBoostItemState : AbstractItemState
    {
        public SpeedBoostItemState(AbstractBlock block) : base(block)
        {
            this.block = block;
        }

        public override void ReleaseItem()
        {
            SpeedBoostItem speedBoostItem = new SpeedBoostItem(new Vector2(block.Location().X, block.Location().Y - block.GetHitBox().Height));
            GameManager.Instance.AddToCollidables(speedBoostItem);
            speedBoostItem.Physics.xVelocity = Config.GetItemMovementSpeed();
            block.itemState = new EmptyItemState(block);
        }
    }
}
