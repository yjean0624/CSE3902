using System;
using Project.GameObjects;
using Project.Blocks;

namespace Project.Collision
{
    public class PlayerGroundBlockCollisionResolution : ICollisionHandler
    {
        private IMario player;
        private GroundBlock groundBlock;
        public PlayerGroundBlockCollisionResolution()
        {
        }
        public void Handle(ICollidable player, ICollidable groundBlock, CollisionDirection.DirectionTag direction)
        {
            if (typeof(IMario).IsInstanceOfType(player) && typeof(GroundBlock).IsInstanceOfType(groundBlock))
            {
                this.player = (IMario)player;
                this.groundBlock = (GroundBlock)groundBlock;
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        this.player.SetYPosition(this.groundBlock.GetTopSide() - player.GetHeight());
                        this.player.Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        this.player.SetYPosition(this.groundBlock.GetBottomSide() + 1);
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        this.player.SetXPosition(this.groundBlock.GetLeftSide() - player.GetWidth());
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        this.player.SetXPosition(this.groundBlock.GetRightSide() + 1);
                        break;
                    default:
                        Console.WriteLine(Config.GetCollisionResolutionException() + GetType().ToString());
                        break;
                }
            }
        }
    }
}
