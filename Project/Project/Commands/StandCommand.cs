using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class StandCommand : ICommand
    {
        private int playerIndex;
        public StandCommand(int playerIndex)
        {
            this.playerIndex = playerIndex;
        }
        public void Execute()
        {
            ((IPlayer)GameManager.Instance.GetMarios()[playerIndex]).Stand();
        }
    }
}
