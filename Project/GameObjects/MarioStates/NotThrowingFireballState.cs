using Project.Levels;
using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public class NotThrowingFireballState : FireballThrowingState
    {
        public NotThrowingFireballState(FireMarioState fireMarioState) : base(fireMarioState)
        {
        }

        public override void ThrowFireball(Vector2 location, Vector2 velocity)
        {
            Fireball newFireball = new Fireball(location , velocity);
            GameManager.Instance.AddToCollidables(newFireball);
            fireMarioState.fireballThrowingState = new ThrowingFireballState(fireMarioState);
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.ThrowFireball);
        }
    }
}
