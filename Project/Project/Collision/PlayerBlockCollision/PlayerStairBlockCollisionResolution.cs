using System;
using Project.GameObjects;
using Project.Blocks;

namespace Project.Collision
{
    public class PlayerStairBlockCollisionResolution : ICollisionHandler
    {
        private IMario player;
        private StairBlock stairBlock;
        public PlayerStairBlockCollisionResolution()
        {
        }
        public void Handle(ICollidable player, ICollidable stairBlock, CollisionDirection.DirectionTag direction)
        {
            if (typeof(IMario).IsInstanceOfType(player) && typeof(StairBlock).IsInstanceOfType(stairBlock))
            {
                this.player = (IMario)player;
                this.stairBlock = (StairBlock)stairBlock;

                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        this.player.SetYPosition(this.stairBlock.GetTopSide() - player.GetHeight());
                        this.player.Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        this.player.SetYPosition(this.stairBlock.GetBottomSide() + 1);
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        this.player.SetXPosition(this.stairBlock.GetLeftSide() - player.GetWidth());
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        this.player.SetXPosition(this.stairBlock.GetRightSide() + 1);
                        break;
                    default:
                        Console.WriteLine("Unexpected Direction Received in Collision.PlayerWithQuestionBlock");
                        break;
                }
            }
        }
    }
}
