using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class StandCommand : ICommand
    {
        private GameManager.PlayerTag tag;
        public StandCommand(GameManager.PlayerTag tag)
        {
            this.tag = tag;
        }
        public void Execute()
        {
            GameManager.Instance.GetMario(tag).Stand();
        }
    }
}
