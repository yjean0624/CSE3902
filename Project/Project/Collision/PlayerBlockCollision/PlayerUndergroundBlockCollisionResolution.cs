using System;
using Project.GameObjects;
using Project.Blocks;

namespace Project.Collision
{
    public class PlayerUndergroundBlockCollisionResolution : ICollisionHandler
    {
        private IMario player;
        private UndergroundBlock undergroundBlock;
        public PlayerUndergroundBlockCollisionResolution()
        {
        }
        public void Handle(ICollidable player, ICollidable undergroundBlock, CollisionDirection.DirectionTag direction)
        {
            if (typeof(IMario).IsInstanceOfType(player) && typeof(UndergroundBlock).IsInstanceOfType(undergroundBlock))
            {
                this.player = (IMario)player;
                this.undergroundBlock = (UndergroundBlock)undergroundBlock;
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        this.player.SetYPosition(this.undergroundBlock.GetTopSide() - player.GetHeight());
                        this.player.Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        this.player.SetYPosition(this.undergroundBlock.GetBottomSide() + 1);
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        this.player.SetXPosition(this.undergroundBlock.GetLeftSide() - player.GetWidth());
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        this.player.SetXPosition(this.undergroundBlock.GetRightSide() + 1);
                        break;
                    default:
                        Console.WriteLine("Unexpected Direction Received in Collision.PlayerWithBrokenBrickBlock");
                        break;
                }
            }
        }
    }
}
