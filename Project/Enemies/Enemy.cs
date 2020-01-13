using Microsoft.Xna.Framework;
using Project.GameObjects;

namespace Project.Enemies
{
    public abstract class Enemy : GameObject, IEnemy
    {
        public Enemy(Vector2 location) : base(location)
        {
        }

        public virtual void Fall()
        {

        }
    }
}
