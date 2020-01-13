using Project.Enemies;
using Project.GameObjects;
using Project.Levels;

namespace Project.Collision
{
    public class EnemyFireballCollisionResolution : ICollisionHandler
    {
        private Enemy enemy;
        private Fireball fireball;
        public EnemyFireballCollisionResolution()
        {
        }
        public void Handle(ICollidable object1, ICollidable object2, CollisionDirection.DirectionTag direction)
        {
            if (typeof(Enemy).IsInstanceOfType(object1) && typeof(Fireball).IsInstanceOfType(object2))
            {
                this.enemy = (Enemy)object1;
                this.fireball = (Fireball)object2;
                fireball.Explode();
                GameManager.Instance.Remove(enemy);
                GameManager.Instance.Remove(fireball);
            }
        }
    }
}
