using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Enemies.EnemyStates.KoopaState
{
    public interface IKoopaState
    {
        void Update(GameTime gameTime);
    }
}
