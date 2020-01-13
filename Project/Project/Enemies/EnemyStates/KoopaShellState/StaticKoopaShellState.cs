using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Enemies.EnemyStates.KoopaShellState
{
    public class StaticKoopaShellState: IKoopaShellState
    {
        private KoopaShell koopaShell;
        public StaticKoopaShellState(KoopaShell koopaShell)
        {
            this.koopaShell = koopaShell;
        }

        public void BeFlipped()
        {
            throw new NotImplementedException();
        }

        public void ChangeDirection()
        {
        }

        public void Kick()
        {

        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
