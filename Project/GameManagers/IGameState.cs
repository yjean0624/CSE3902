using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
        void Update(GameTime gameTime, ContentManager content);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime, float screenWidth, float screenHeight);
    }
}
