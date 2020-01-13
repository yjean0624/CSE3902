using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.GameManagers
{
    public interface IPausedState
    {
        void Pause();
        void Unpause();
        bool IsPaused();
        void Update(GameTime gameTime, ContentManager content);
    }
}
