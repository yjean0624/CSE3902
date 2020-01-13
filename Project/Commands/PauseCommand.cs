using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class PauseCommand : ICommand
    {
        public PauseCommand()
        {
        }
        public void Execute()
        {
            GameManager.Instance.Pause();
        }
    }
}
