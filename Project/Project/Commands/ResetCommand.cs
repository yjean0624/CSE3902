using Project.Levels;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project.Commands
{
    class ResetCommand : ICommand
    {
        private Game game;
        public ResetCommand(Game game)
        {
            this.game = game;
        }
        public void Execute()
        {
            GameManager.Instance.ReloadLevel(game.Content);
        }
    }
}
