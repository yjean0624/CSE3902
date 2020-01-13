using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Project.Controllers;
using Project.GameManagers;
using Project.Sound;

namespace Project
{
    public class PausedGameState : IPausedState
    {
        private GamePlayState state;
        public PausedGameState(GamePlayState state)
        {
            this.state = state;
            SoundEffectManager.Instance.PlaySoundEffect(SoundEffectManager.SoundEffectTag.Pause);
            SoundEffectManager.Instance.PauseBackgroundMusic();
        }
        public bool IsPaused()
        {
            return true;
        }

        public void Pause()
        {
            //Do Nothing
        }

        public void Unpause()
        {
            state.pauseState = new UnpausedGameState(state);
        }

        public void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public void Update(GameTime gameTime, ContentManager content)
        {
            ControllerController.Instance.UpdateGameController();
        }
    }
}
