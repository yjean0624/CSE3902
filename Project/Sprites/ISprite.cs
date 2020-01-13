using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project.GameObjects;

namespace Project.Sprites
{
    public interface ISprite : IUpdatable
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
        int GetWidth();
        int GetHeight();
    }
}
