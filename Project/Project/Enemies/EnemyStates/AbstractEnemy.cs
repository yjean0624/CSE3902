using Microsoft.Xna.Framework;
using Project.Enemies.EnemyStates.KoopaState;
using Project.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Enemies.EnemyStates
{
    public abstract class AbstractEnemy: GameObject, IEnemy
    {
        public AbstractEnemy(Vector2 location) : base(location)
        {
        }

        public virtual void Clean()
        {
            GameManager.Instance.Remove(this);
        }
    }
}
