using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class CollectStarCommand : ICommand
    {
        private GameManager.PlayerTag tag;
        public CollectStarCommand(GameManager.PlayerTag tag)
        {
            this.tag = tag;
        }
        public void Execute()
        {
            GameManager.Instance.GetMario(tag).CollectStar();
        }
    }
}
