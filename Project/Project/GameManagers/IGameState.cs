using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.GameManagers
{
    public interface IGameState
    {
        void Pause();
        void Unpause();
        bool IsPaused();
    }
}
