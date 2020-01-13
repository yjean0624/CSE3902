using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class JumpCommand : ICommand
    {
        private int playerIndex;
        public JumpCommand(int playerIndex)
        {
            this.playerIndex = playerIndex;
        }
        public void Execute()
        {
            ((IPlayer)GameManager.Instance.GetMarios()[playerIndex]).Jump();
        }
    }
}
