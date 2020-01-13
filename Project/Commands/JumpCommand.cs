using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class JumpCommand : ICommand
    {
        private GameManager.PlayerTag tag;
        public JumpCommand(GameManager.PlayerTag tag)
        {
            this.tag = tag;
        }
        public void Execute()
        {
            GameManager.Instance.GetMario(tag).Jump();
        }
    }
}
