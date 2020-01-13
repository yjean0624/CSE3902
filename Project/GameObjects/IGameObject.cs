using Microsoft.Xna.Framework;

namespace Project.GameObjects
{
    public interface IGameObject : IDrawable, IUpdatable
    {
        Vector2 Location();
    }
}
