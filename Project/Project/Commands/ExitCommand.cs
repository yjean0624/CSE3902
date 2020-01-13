using Microsoft.Xna.Framework;

namespace Project.Commands
{
    /*
     * The exit command
     */ 
    class ExitCommand : ICommand
    {
        private Game game;
        public ExitCommand(Game game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Exit();
        }
    }
}
