using Microsoft.Xna.Framework.Content;

namespace Project.Commands
{
    class ResetGameCommand : ICommand
    {
        ContentManager content;
        public ResetGameCommand(ContentManager content)
        {
            this.content = content;
        }
        public void Execute()
        {
            GameManager.Instance.ResetGame(content);
        }
    }
}
