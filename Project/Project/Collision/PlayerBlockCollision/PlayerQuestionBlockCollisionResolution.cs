using System;
using Project.GameObjects;
using Project.Blocks;

namespace Project.Collision
{
    public class PlayerQuestionBlockCollisionResolution : ICollisionHandler
    {
        private IMario player;
        private AbstractQuestionBlock questionBlock;
        public PlayerQuestionBlockCollisionResolution()
        {
        }
        public void Handle(ICollidable player, ICollidable questionBlock, CollisionDirection.DirectionTag direction)
        {
            if (typeof(IMario).IsInstanceOfType(player) && typeof(AbstractQuestionBlock).IsInstanceOfType(questionBlock))
            {
                this.player = (IMario)player;
                this.questionBlock = (AbstractQuestionBlock)questionBlock;
                //Console.WriteLine(questionBlock.GetHitBox().X + " " + questionBlock.GetHitBox().Y);

                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        this.player.SetYPosition(this.questionBlock.GetTopSide() - player.GetHeight());
                        this.player.Ground();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        this.player.SetYPosition(this.questionBlock.GetBottomSide() + 1);
                        this.questionBlock.Bump();
                        this.questionBlock.EndBump();
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        this.player.SetXPosition(this.questionBlock.GetLeftSide() - player.GetWidth());
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        this.player.SetXPosition(this.questionBlock.GetRightSide() + 1);
                        break;
                    default:
                        Console.WriteLine("Unexpected Direction Received in Collision.PlayerWithQuestionBlock");
                        break;
                }
            }
        }
    }
}
