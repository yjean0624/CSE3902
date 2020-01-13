using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class MoveRightCommand : ICommand
    {
        private GameManager.PlayerTag tag;
        public MoveRightCommand(GameManager.PlayerTag tag)
        {
            this.tag = tag;
        }
        public void Execute()
        {
            GameManager.Instance.GetMario(tag).MoveRight();
        }
    }
}
