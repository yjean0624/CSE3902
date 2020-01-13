using Project.GameManagers;

namespace Project
{
    public class UnpausedGameState : IGameState
    {
        public UnpausedGameState()
        {
        }
        public bool IsPaused()
        {
            return false;
        }

        public void Pause()
        {
            GameManager.Instance.GameState = new PausedGameState();
        }

        public void Unpause()
        {
            //Do Nothing
        }
    }
}
