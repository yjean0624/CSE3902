using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    class CrouchCommand : ICommand
    {
        private int playerIndex;
        public CrouchCommand(int playerIndex)
        {
            this.playerIndex = playerIndex;
        }
        public void Execute()
        {
            ((IPlayer)GameManager.Instance.GetMarios()[playerIndex]).Crouch();
        }
    }
}
