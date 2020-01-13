using Project.GameObjects;
using Project.Collision;

namespace Project.Blocks
{
    public interface IBlock : IGameObject, ICollidable
    {
        void Bump();
        void EndBump();
        bool IsBumped();
    }
}
