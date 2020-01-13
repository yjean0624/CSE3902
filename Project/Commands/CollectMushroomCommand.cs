using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class CollectMushroomCommand : ICommand
    {
        private GameManager.PlayerTag tag;
        public CollectMushroomCommand(GameManager.PlayerTag tag)
        {
            this.tag = tag;
        }
        public void Execute()
        {
            GameManager.Instance.GetMario(tag).CollectBrownMushroom();
        }
    }
}
