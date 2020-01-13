using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Enemies.EnemyStates.KoopaShellState
{
    public class FlippedKoopaShellState : IKoopaShellState
    {
        private KoopaShell koopaShell;
        public FlippedKoopaShellState(KoopaShell koopaShell)
        {
            this.koopaShell = koopaShell;
        }

        public void BeFlipped()
        {
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
