using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project.GameObjects
{
    public interface IMario : IPlayer
    {
        void CollectBrownMushroom();
        void CollectGreenMushroom();
        void CollectFlower();
        void CollectStar();
        void ThrowFireball();
        void StopThrowingFireball();
        bool IsSmall();
        bool IsBig();
        bool IsFire();
        bool IsCrouching();
        void Draw(SpriteBatch spriteBatch, Color color);
        void SetXPosition(int x);
        void SetYPosition(int y);
        void LoseLife();
        void GainLife();
    }
}
