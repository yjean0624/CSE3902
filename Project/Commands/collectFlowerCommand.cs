using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class CollectFlowerCommand : ICommand
    {

        private GameManager.PlayerTag tag;
        public CollectFlowerCommand(GameManager.PlayerTag tag)
        {
            this.tag = tag;
        }
        public void Execute()
        {
            GameManager.Instance.GetMario(tag).CollectFlower();
        }
    }
}
