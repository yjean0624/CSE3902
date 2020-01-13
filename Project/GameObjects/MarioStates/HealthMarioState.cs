using Microsoft.Xna.Framework;

namespace Project.GameObjects.MarioStates
{
    public abstract class HealthMarioState : IHealthState
    {
        protected Mario gameObject;
        protected HealthMarioState(Mario gameObject)
        {
            this.gameObject = gameObject;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public abstract void TakeDamage();
        public abstract void CollectBrownMushroom();
        public abstract void CollectFlower();
        public abstract void CollectStar();

        public virtual bool IsBig()
        {
            return false;
        }

        public virtual bool IsDead()
        {
            return false;
        }

        public virtual bool IsFire()
        {
            return false;
        }

        public virtual bool IsSmall()
        {
            return false;
        }

        public virtual bool IsStar()
        {
            return false;
        }

        public virtual void ThrowFireball(Vector2 location, Vector2 velocity)
        {

        }

        public virtual void StopThrowingFireball()
        {

        }
    }
}
