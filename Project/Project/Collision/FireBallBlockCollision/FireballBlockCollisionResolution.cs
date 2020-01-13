using Project.GameObjects;
using Project.Blocks;
using System;

namespace Project.Collision
{
    public class FireballBlockCollisionResolution : ICollisionHandler
    {
        private Fireball fireball;
        private AbstractBlock block;
        public FireballBlockCollisionResolution()
        {
        }
        public void Handle(ICollidable object1, ICollidable object2, CollisionDirection.DirectionTag direction)
        {
            if (typeof(Fireball).IsInstanceOfType(object1) && typeof(AbstractBlock).IsInstanceOfType(object2))
            {
                fireball = (Fireball)object1;
                block = (AbstractBlock)object2;
                if (typeof(StairBlock).IsInstanceOfType(object2))
                {
                    fireball.Explode();
                    GameManager.Instance.Remove(fireball);
                }
                else
                {
                    switch (direction)
                    {
                        case CollisionDirection.DirectionTag.Top:
                            fireball.BounceVertically();
                            break;
                        case CollisionDirection.DirectionTag.Bottom:
                            fireball.BounceVertically();
                            break;
                        case CollisionDirection.DirectionTag.Left:
                            fireball.BounceHorizontally();
                            break;
                        case CollisionDirection.DirectionTag.Right:
                            fireball.BounceHorizontally();
                            break;
                        default:
                            Console.WriteLine("Unexpected direction received by FireballBlockCollisionResolution");
                            break;
                    }
                }
            }
        }
    }
}
