using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class CollectStarCommand : ICommand
    {
        private int playerIndex;
        public CollectStarCommand(int playerIndex)
        {
            this.playerIndex = playerIndex;
        }
        public void Execute()
        {
            ((IMario)GameManager.Instance.GetMarios()[playerIndex]).CollectStar();
        }
    }
}
