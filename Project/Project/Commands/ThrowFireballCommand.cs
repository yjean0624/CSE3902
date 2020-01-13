using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class ThrowFireballCommand : ICommand
    {
        private int playerIndex;
        public ThrowFireballCommand(int playerIndex)
        {
            this.playerIndex = playerIndex;
        }
        public void Execute()
        {
            ((IMario)GameManager.Instance.GetMarios()[playerIndex]).ThrowFireball();
        }
    }
}
