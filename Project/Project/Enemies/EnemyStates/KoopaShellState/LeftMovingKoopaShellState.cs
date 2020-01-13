using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Enemies.EnemyStates.KoopaShellState
{
    public class LeftMovingKoopaShellState:IKoopaShellState
    {
        private KoopaShell koopaShell;
        public LeftMovingKoopaShellState(KoopaShell koopaShell)
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
            throw new NotImplementedException();
        }

        public void Shell()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
