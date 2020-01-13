using System;
using Project.GameObjects;
using Project.Blocks;

namespace Project.Collision
{
    public class PlayerInvisibleBlockCollisionResolution : ICollisionHandler
    {
        private IMario player;
        private InvisibleBlock invisibleBlock;
        public PlayerInvisibleBlockCollisionResolution()
        {
        }
        public void Handle(ICollidable player, ICollidable invisibleBlock, CollisionDirection.DirectionTag direction)
        {
            if (typeof(IMario).IsInstanceOfType(player) && typeof(InvisibleBlock).IsInstanceOfType(invisibleBlock))
            {
                this.player = (IMario)player;
                this.invisibleBlock = (InvisibleBlock)invisibleBlock;
                Console.WriteLine(invisibleBlock.GetHitBox().X + " " + invisibleBlock.GetHitBox().Y);
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        this.player.SetYPosition(this.invisibleBlock.GetBottomSide() + 1);
                        this.invisibleBlock.Bump();
                        this.invisibleBlock.EndBump();
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        break;
                    default:
                        Console.WriteLine("Unexpected Direction Received in Collision.PlayerWithInvisibleBlock");
                        break;
                }
            }
        }
    }
}
