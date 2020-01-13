using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class CollectMushroomCommand : ICommand
    {
        private int playerIndex;
        public CollectMushroomCommand(int playerIndex)
        {
            this.playerIndex = playerIndex;
        }
        public void Execute()
        {
            ((IMario)GameManager.Instance.GetMarios()[playerIndex]).CollectBrownMushroom();
        }
    }
}
