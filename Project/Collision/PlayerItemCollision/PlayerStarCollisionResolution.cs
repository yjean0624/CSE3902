using Project.GameObjects;
using Project.Items;


namespace Project.Collision
{
    public class PlayerStarCollisionResolution : ICollisionHandler
    {
        private Mario mario;
        private Star star;
        public PlayerStarCollisionResolution()
        {
        }
        public void Handle(ICollidable object1, ICollidable object2, CollisionDirection.DirectionTag direction)
        {
            if (object1.GetType() == typeof(Mario) && object2.GetType() == typeof(Star))
            {
                mario = (Mario)object1;
                star = (Star)object2;
                switch (direction)
                {
                    case CollisionDirection.DirectionTag.Top:
                        //Mario should stay unchanged//
                        mario.CollectStar();
                        //Star disappear//
                        this.star.Collect();
                        break;
                    case CollisionDirection.DirectionTag.Bottom:
                        //Mario should stay unchanged//
                        mario.CollectStar();
                        //Star disappear//
                        this.star.Collect();
                        break;
                    case CollisionDirection.DirectionTag.Left:
                        //Mario should stay unchanged//
                        mario.CollectStar();
                        //Star disappear//
                        this.star.Collect();
                        break;
                    case CollisionDirection.DirectionTag.Right:
                        //Mario should stay unchanged//
                        mario.CollectStar();
                        //Star disappear//
                        this.star.Collect();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
