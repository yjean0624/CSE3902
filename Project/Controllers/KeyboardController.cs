using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Project.Commands;

namespace Project.Controllers
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> keyDownMap;
        private Dictionary<Keys, ICommand> keyUpMap;
        public KeyboardController(Game game)
        {
            List<(Keys, ICommand)> keyDownMap = new List<(Keys, ICommand)>();
            keyDownMap.Add((Keys.Q, new ExitCommand(game)));
            keyDownMap.Add((Keys.A, new MoveLeftCommand(0)));
            keyDownMap.Add((Keys.D, new MoveRightCommand(0)));
            keyDownMap.Add((Keys.W, new JumpCommand(0)));
            keyDownMap.Add((Keys.S, new CrouchCommand(0)));
            keyDownMap.Add((Keys.B, new BoostCommand(0)));
            keyDownMap.Add((Keys.LeftShift, new ThrowFireballCommand(0)));
            keyDownMap.Add((Keys.U, new CollectMushroomCommand(0)));
            keyDownMap.Add((Keys.I, new CollectFlowerCommand(0)));
            keyDownMap.Add((Keys.P, new CollectStarCommand(0)));
            keyDownMap.Add((Keys.M, new PauseCommand()));
            keyDownMap.Add((Keys.N, new UnpauseCommand()));
            List<(Keys, ICommand)> keyUpMap = new List<(Keys, ICommand)>();
            keyUpMap.Add((Keys.W, new StopJumpingCommand(0)));
            keyUpMap.Add((Keys.LeftShift, new StopThrowingFireballCommand(0)));
            keyUpMap.Add((Keys.S, new StandCommand(0)));

            this.keyDownMap = new Dictionary<Keys, ICommand>();
            foreach ((Keys, ICommand) keyBinding in keyDownMap)
            {
                this.keyDownMap.Add(keyBinding.Item1, keyBinding.Item2);
            }
            this.keyUpMap = new Dictionary<Keys, ICommand>();
            foreach ((Keys, ICommand) keyBinding in keyUpMap)
            {
                this.keyUpMap.Add(keyBinding.Item1, keyBinding.Item2);
            }
        }
        public KeyboardController((Keys, ICommand)[] keyDownMap, (Keys, ICommand)[] keyUpMap)
        {
            this.keyDownMap = new Dictionary<Keys, ICommand>();
            foreach ((Keys, ICommand) keyBinding in keyDownMap)
            {
                this.keyDownMap.Add(keyBinding.Item1, keyBinding.Item2);
            }
            this.keyUpMap = new Dictionary<Keys, ICommand>();
            foreach ((Keys, ICommand) keyBinding in keyUpMap)
            {
                this.keyUpMap.Add(keyBinding.Item1, keyBinding.Item2);
            }
        }

        public void Update()
        {
            foreach (KeyValuePair<Keys, Commands.ICommand> entry in keyDownMap)
            {
                if (Keyboard.GetState().IsKeyDown(entry.Key))
                {
                    entry.Value.Execute();
                }
            }
            foreach (KeyValuePair<Keys, Commands.ICommand> entry in keyUpMap)
            {
                if (!Keyboard.GetState().IsKeyDown(entry.Key))
                {
                    entry.Value.Execute();
                }
            }
        }
    }
}
