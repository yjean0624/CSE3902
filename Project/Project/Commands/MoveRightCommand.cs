using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class MoveRightCommand : ICommand
    {
        private int playerIndex;
        public MoveRightCommand(int playerIndex)
        {
            this.playerIndex = playerIndex;
        }
        public void Execute()
        {
            ((IPlayer)GameManager.Instance.GetMarios()[playerIndex]).MoveRight();
        }
    }
}
