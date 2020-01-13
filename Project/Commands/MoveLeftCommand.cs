using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class MoveLeftCommand : ICommand
    {
        private GameManager.PlayerTag tag;
        public MoveLeftCommand(GameManager.PlayerTag tag)
        {
            this.tag = tag;
        }
        public void Execute()
        {
            GameManager.Instance.GetMario(tag).MoveLeft();
        }
    }
}
