using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class CrouchCommand : ICommand
    {
        private GameManager.PlayerTag tag;
        public CrouchCommand(GameManager.PlayerTag tag)
        {
            this.tag = tag;
        }
        public void Execute()
        {
            GameManager.Instance.GetMario(tag).Crouch();
        }
    }
}
