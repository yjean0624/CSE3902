using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class UnpauseCommand : ICommand
    {
        public UnpauseCommand()
        {
        }
        public void Execute()
        {
            GameManager.Instance.Unpause();
        }
    }
}
