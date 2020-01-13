using Project.Collision;
using Project.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Enemies.EnemyStates
{
    public interface IEnemy: IGameObject, ICollidable
    {
        void Clean();
    }
}
