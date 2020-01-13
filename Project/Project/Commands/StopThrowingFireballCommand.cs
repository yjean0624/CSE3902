using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class StopThrowingFireballCommand : ICommand
    {
        private int playerIndex;
        public StopThrowingFireballCommand(int playerIndex)
        {
            this.playerIndex = playerIndex;
        }
        public void Execute()
        {
            ((IMario)GameManager.Instance.GetMarios()[playerIndex]).StopThrowingFireball();
        }
    }
}
