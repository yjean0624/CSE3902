using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class ThrowFireballCommand : ICommand
    {
        private GameManager.PlayerTag tag;
        public ThrowFireballCommand(GameManager.PlayerTag tag)
        {
            this.tag = tag;
        }
        public void Execute()
        {
            GameManager.Instance.GetMario(tag).ThrowFireball();
        }
    }
}
