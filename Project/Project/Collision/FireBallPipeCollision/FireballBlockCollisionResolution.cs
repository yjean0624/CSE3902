using Project.GameObjects;
using Project.Pipes;
using System;

namespace Project.Collision
{
    public class FireballPipeCollisionResolution : ICollisionHandler
    {
        private Fireball fireball;
        private AbstractPipe pipe;
        public FireballPipeCollisionResolution()
        {
        }
        public void Handle(ICollidable object1, ICollidable object2, CollisionDirection.DirectionTag direction)
        {
            if (typeof(Fireball).IsInstanceOfType(object1) && typeof(AbstractPipe).IsInstanceOfType(object2))
            {
                fireball = (Fireball)object1;
                pipe = (AbstractPipe)object2;
                fireball.Explode();
                GameManager.Instance.Remove(fireball);
            }
        }
    }
}
