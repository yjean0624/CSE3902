using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class StopThrowingFireballCommand : ICommand
    {
        private GameManager.PlayerTag tag;
        public StopThrowingFireballCommand(GameManager.PlayerTag tag)
        {
            this.tag = tag;
        }
        public void Execute()
        {
            GameManager.Instance.GetMario(tag).StopThrowingFireball();
        }
    }
}
