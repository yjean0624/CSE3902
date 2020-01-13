using Microsoft.Xna.Framework;
using Project.Sprites;
using Project.Levels;

namespace Project.GameObjects
{
    public class Fireball : Projectile
    {
        public Fireball(Vector2 location, Vector2 velocity): base(location, velocity)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.Fireball);
        }

        public void Explode()
        {
            GameManager.Instance.Remove(this);
            FireballExplosion newFireballExplosion = new FireballExplosion(Location());
            GameManager.Instance.AddToNonCollidables(newFireballExplosion);
        }

        public void BounceVertically()
        {
            Physics.yVelocity = Config.GetProjectileMovementSpeed();
        }

        public void BounceHorizontally()
        {
            Physics.xVelocity *= -1;
        }
    }
}
