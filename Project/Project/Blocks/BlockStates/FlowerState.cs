using Project.Levels;
using Project.Items;
using Microsoft.Xna.Framework;

namespace Project.Blocks
{
    public class FlowerState : AbstractItemState
    {
        public FlowerState(AbstractBlock block) : base(block)
        {
            this.block = block;
        }
        public override void ReleaseItem()
        {
            Flower flower = new Flower(new Vector2(this.block.Location().X, this.block.Location().Y - this.block.GetHitBox().Height));
            GameManager.Instance.AddToCollidables(flower);
            flower.Physics.yAcceleration = Config.GetGravity();
            block.itemState = new EmptyItemState(block);
        }
    }
}
