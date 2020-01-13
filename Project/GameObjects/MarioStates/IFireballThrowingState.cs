using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public interface IFireballThrowingState
    {
        void ThrowFireball(Vector2 location, Vector2 velocity);

        void StopThrowingFireball();
    }
}
