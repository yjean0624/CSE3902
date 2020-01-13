using System;
using Project.GameObjects;
using Project.Blocks;
using Project.Sound;

namespace Project.Collision
{
    public class PlayerWithBrickBlockResponse : ICollisionHandler
    {
        private IMario mario;
        private NormalBrickBlock brickBlock;
        public PlayerWithBrickBlockResponse()
        {
        }
        public void Handle(ICollidable player, ICollidable brickBlock, CollisionDirection.DirectionTag direction)
        {
            if (typeof(IMario).IsInstanceOfType(player) && typeof(NormalBrickBlock).IsInstanceOfType(brickBlock))
            {
                mario = (IMario)player;
                this.brickBlock = (NormalBrickBlock)brickBlock;
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        mario.SetYPosition(brickBlock.GetTopSide() - player.GetHeight());
                        mario.Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        mario.StopJumping();
                        mario.SetYPosition(this.brickBlock.GetBottomSide() + 1);
                        this.brickBlock.Bump();
                        this.brickBlock.EndBump();
                        if (!mario.IsSmall())
                        {
                            this.brickBlock.Break();
                        }
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        mario.SetXPosition(this.brickBlock.GetLeftSide() - player.GetWidth());
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        mario.SetXPosition(this.brickBlock.GetRightSide() + 1);
                        break;
                    default:
                        Console.WriteLine(Config.GetCollisionResolutionException() + GetType().ToString());
                        break;
                }
            }
        }
    }
}
