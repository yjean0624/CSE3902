using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Project.Collision;
using Project.Controllers;
using Project.GameManagers;
using Project.GameObjects;
using Project.Sound;

namespace Project
{
    public class UnpausedGameState : IPausedState
    {
        private GamePlayState state;
        public UnpausedGameState(GamePlayState state)
        {
            this.state = state;
            SoundEffectManager.Instance.ResumeBackgroundMusic();
        }
        public bool IsPaused()
        {
            return false;
        }

        public void Pause()
        {
            state.pauseState = new PausedGameState(state);
        }

        public void Unpause()
        {
            //Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            foreach(IGameObject gameObject in GameManager.Instance.GetAllObjectsInCollisionOrder())
            {
                gameObject.Update(gameTime);
            }
        }

        public void Update(GameTime gameTime, ContentManager content)
        {
            foreach (IGameObject gameObject in GameManager.Instance.GetAllObjectsInCollisionOrder())
            {
                gameObject.Update(gameTime);
            }
            CollisionDetector.Instance.DetectCollision();
            ControllerController.Instance.Update();
            GameManager.Instance.AddMilliseconds(gameTime.ElapsedGameTime.Milliseconds);
        }
    }
}
