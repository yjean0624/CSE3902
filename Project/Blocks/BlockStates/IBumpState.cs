using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blocks
{
    public interface IBumpState
    {
        void EndBump();
        bool IsBumped();
        void Bump();
    }
}
