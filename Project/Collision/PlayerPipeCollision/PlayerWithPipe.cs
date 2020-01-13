using System;
using Project.GameObjects;
using Project.Pipes;

namespace Project.Collision
{
    public class PlayerPipeCollisionResolution : ICollisionHandler
    {
        private IMario player;
        private AbstractPipe pipe;
        public PlayerPipeCollisionResolution()
        {
        }
        public void Handle(ICollidable player, ICollidable pipe, CollisionDirection.DirectionTag direction)
        {
            if (typeof(IMario).IsInstanceOfType(player) && typeof(AbstractPipe).IsInstanceOfType(pipe))
            {
                this.player = (IMario)player;
                this.pipe = (AbstractPipe)pipe;

                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        this.player.SetYPosition(this.pipe.GetTopSide() - player.GetHeight());
                        if (typeof(TeleportationPipe).IsInstanceOfType(pipe) && this.player.IsCrouching())
                        {
                            ((TeleportationPipe)pipe).Teleport();
                        }
                        else
                        {
                            this.player.Ground();
                        }
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        this.player.SetYPosition(this.pipe.GetBottomSide() + 1);
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        this.player.SetXPosition(this.pipe.GetLeftSide() - player.GetWidth());
                        if (typeof(LeftFacingPipe).IsInstanceOfType(this.pipe) && this.player.IsCrouching())
                        { 
                            //IsCrouching need to be changed to IsMovingRight
                            ((LeftFacingPipe)pipe).Teleport();
                        }
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        this.player.SetXPosition(this.pipe.GetRightSide() + 1);
                        break;
                    default:
                        Console.WriteLine(Config.GetCollisionResolutionException() + GetType().ToString());
                        break;
                }
            }
        }
    }
}
