using System;
using Project.GameObjects;
using Project.Blocks;

namespace Project.Collision
{
    public class PlayerSolidBlockCollisionResolution : ICollisionHandler
    {
        private IMario player;
        private SolidBlock solidBlock;
        public PlayerSolidBlockCollisionResolution()
        {
        }
        public void Handle(ICollidable player, ICollidable solidBlock, CollisionDirection.DirectionTag direction)
        {
            if (typeof(IMario).IsInstanceOfType(player) && typeof(SolidBlock).IsInstanceOfType(solidBlock))
            {
                this.player = (IMario)player;
                this.solidBlock = (SolidBlock)solidBlock;
                Console.WriteLine(this.solidBlock.Physics.xPosition + " " + this.solidBlock.Physics.yPosition);
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        this.player.SetYPosition(this.solidBlock.GetTopSide() - player.GetHeight());
                        this.player.Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        ((GameObject)player).Physics.yVelocity = 0;
                        this.player.StopJumping();
                        this.player.SetYPosition(this.solidBlock.GetBottomSide() + 1);
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        this.player.SetXPosition(this.solidBlock.GetLeftSide() - player.GetWidth());
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        this.player.SetXPosition(this.solidBlock.GetRightSide() + 1);
                        break;
                    default:
                        Console.WriteLine(Config.GetCollisionResolutionException() + GetType().ToString());
                        break;
                }
            }
        }
    }
}
