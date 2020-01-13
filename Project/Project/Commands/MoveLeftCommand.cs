using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class MoveLeftCommand : ICommand
    {
        private int playerIndex;
        public MoveLeftCommand(int playerIndex)
        {
            this.playerIndex = playerIndex;
        }
        public void Execute()
        {
            ((IPlayer)GameManager.Instance.GetMarios()[playerIndex]).MoveLeft();
        }
    }
}
