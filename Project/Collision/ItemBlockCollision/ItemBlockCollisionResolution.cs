using Project.Items;
using Project.Blocks;
using System;

namespace Project.Collision
{
    public class ItemBlockCollisionResolution : ICollisionHandler
    {
        private Item item;
        private AbstractBlock block;
        public ItemBlockCollisionResolution()
        {
        }
        public void Handle(ICollidable item, ICollidable block, CollisionDirection.DirectionTag direction)
        {
            if (typeof(Item).IsInstanceOfType(item) && typeof(AbstractBlock).IsInstanceOfType(block))
            {
                this.item = (Item)item;
                this.block = (AbstractBlock)block;
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        this.item.Physics.yPosition = this.block.GetTopSide() - this.item.GetHeight();
                        this.item.Ground();
                        if (typeof(Star).IsInstanceOfType(item))
                        {
                            //FIXME: QUICK FIX
                            ((Star)item).Bounce();
                        }
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        this.item.Physics.yPosition = this.block.GetBottomSide() + 1;
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        this.item.Physics.xPosition = this.block.GetLeftSide() - this.item.GetWidth();
                        this.item.ChangeDirection();
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        this.item.Physics.xPosition = this.block.GetRightSide() + 1;
                        this.item.ChangeDirection();
                        break;
                    default:
                        Console.WriteLine(Config.GetCollisionResolutionException() + GetType().ToString());
                        break;
                }
                if (typeof(SpawnedCoin).IsInstanceOfType(item))
                {
                    ((SpawnedCoin)item).Collect();
                }
            }
        }
    }
}
