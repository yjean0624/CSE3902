using Project.GameManagers;
using Project.Sound;

namespace Project
{
    public class PausedGameState : IGameState
    {
        public PausedGameState()
        {
            SoundEffectManager.Instance.PlaySoundEffect(SoundEffectManager.SoundEffectTag.Pause);
            SoundEffectManager.Instance.PauseBGM();
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
            GameManager.Instance.GameState = new UnpausedGameState();
        }
    }
}
