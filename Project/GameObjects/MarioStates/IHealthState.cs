using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public interface IHealthState
    {
        void CollectBrownMushroom();

        void CollectFlower();

        void TakeDamage();

        void CollectStar();

        void ThrowFireball(Vector2 location, Vector2 velocity);

        void StopThrowingFireball();

        void Update(GameTime gameTime);

        bool IsBig();

        bool IsSmall();

        bool IsFire();

        bool IsDead();

        bool IsStar();
    }
}
