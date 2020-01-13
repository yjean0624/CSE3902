using Microsoft.Xna.Framework;


namespace Project.GameObjects
{
    public abstract class Projectile : GameObject, IProjectile
    {
        protected Projectile(Vector2 location, Vector2 velocity) : base(location)
        {
            Physics = new Physics(location, velocity.X, velocity.Y);
        }
    }
}
