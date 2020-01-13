using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    public class StopJumpingCommand : ICommand
    {
        private int playerIndex;
        public StopJumpingCommand(int playerIndex)
        {
            this.playerIndex = playerIndex;
        }
        public void Execute()
        {
            ((IPlayer)GameManager.Instance.GetMarios()[playerIndex]).StopJumping();
        }
    }
}
