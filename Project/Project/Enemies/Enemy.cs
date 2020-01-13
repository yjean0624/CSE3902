using Microsoft.Xna.Framework;
using Project.GameObjects;

namespace Project.Enemies
{
    public abstract class Enemy : GameObject, IEnemy
    {
        public bool dead;
        public bool reversedFalling;
        public Enemy(Vector2 location) : base(location)
        {
            dead = false;
            reversedFalling = false;
        }

        public virtual void Clean()
        {
            GameManager.Instance.Remove(this);
        }

        public virtual void Kill() {
            dead = true;
        }

        public virtual void Fall()
        {
            reversedFalling = true;
        }
    }
}
