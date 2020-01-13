using Project.GameObjects;

namespace Project.Collision
{
    public interface ICollisionHandler
    {
         void Handle(ICollidable object1, ICollidable object2, CollisionDirection.DirectionTag direction);
    }
}
