using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Camera;
using Project.GameObjects;

namespace Project.GameManagers
{
    public class GamePlayState : IGameState
    {
        public IPausedState pauseState;
        public GamePlayState()
        {
            pauseState = new UnpausedGameState(this);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, float screenWidth, float screenHeight)
        {
            CameraController.Instance.Draw(spriteBatch, gameTime, screenWidth, screenHeight);
        }

        public bool IsPaused()
        {
            return pauseState.IsPaused();
        }

        public void Pause()
        {
            pauseState.Pause();
        }

        public void Unpause()
        {
            pauseState.Unpause();
        }

        public void Update(GameTime gameTime, ContentManager content)
        {
            pauseState.Update(gameTime, content);
        }
    }
}
