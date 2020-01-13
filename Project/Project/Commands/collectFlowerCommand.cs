using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class CollectFlowerCommand : ICommand
    {
        private int playerIndex;
        public CollectFlowerCommand(int playerIndex)
        {
            this.playerIndex = playerIndex;
        }
        public void Execute()
        {
            ((IMario)GameManager.Instance.GetMarios()[playerIndex]).CollectFlower();
        }
    }
}
