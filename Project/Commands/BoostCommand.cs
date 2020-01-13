using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class BoostCommand : ICommand
    {
        private GameManager.PlayerTag tag;
        public BoostCommand(GameManager.PlayerTag tag)
        {
            this.tag = tag;
        }
        public void Execute()
        {
            GameManager.Instance.GetMario(tag).Boost();
        }
    }
}
