using Project.GameObjects;
using Project.Levels;

namespace Project.Commands
{
    public class StopJumpingCommand : ICommand
    {
        private GameManager.PlayerTag tag;
        public StopJumpingCommand(GameManager.PlayerTag tag)
        {
            this.tag = tag;
        }
        public void Execute()
        {
            GameManager.Instance.GetMario(tag).StopJumping();
        }
    }
}
