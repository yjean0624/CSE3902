using Project.Levels;
using Project.Items;
using Microsoft.Xna.Framework;

namespace Project.Blocks
{
    public class CoinState : AbstractItemState
    {
        public CoinState(AbstractBlock block) : base(block)
        {
            this.block = block;
        }
        public override void ReleaseItem()
        {
            SpawnedCoin coin = new SpawnedCoin(new Vector2(this.block.Location().X, this.block.Location().Y - this.block.GetHitBox().Height));
            GameManager.Instance.AddToCollidables(coin);
            coin.Physics.yVelocity = -250f;
            block.itemState = new EmptyItemState(block);
        }
    }
}
