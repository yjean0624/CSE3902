using Project.Levels;
using Project.Items;
using Microsoft.Xna.Framework;

namespace Project.Blocks
{
    public class GreenMushroomState : AbstractItemState
    {
        public GreenMushroomState(AbstractBlock block) : base(block)
        {
            this.block = block;
        }
        public override void ReleaseItem()
        {
            SpeedBoostItem greenMushroom = new SpeedBoostItem(new Vector2(this.block.Location().X, this.block.Location().Y - this.block.GetHitBox().Height));
            GameManager.Instance.AddToCollidables(greenMushroom);
            greenMushroom.Physics.xVelocity = Config.GetItemMovementSpeed();
            block.itemState = new EmptyItemState(block);
        }
    }
}
