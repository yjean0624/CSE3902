using Project.GameObjects;
using Project.Collision;

namespace Project.Items
{
    public interface IItem : IGameObject, ICollidable, ICollectable
    {
        void ChangeDirection();
    }
}
