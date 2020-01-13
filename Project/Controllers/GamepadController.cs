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
    class GamepadController : IController
    {
        private Dictionary<Buttons, ICommand> buttonDownMap;
        private Dictionary<Buttons, ICommand> buttonUpMap;
        public GamepadController(Game game)
        {
            List<(Buttons, ICommand)> buttonDownMap = new List<(Buttons, ICommand)>();
            buttonDownMap.Add((Buttons.Start, new ExitCommand(game)));
            buttonDownMap.Add((Buttons.LeftThumbstickLeft, new MoveLeftCommand(0)));
            buttonDownMap.Add((Buttons.LeftThumbstickRight, new MoveRightCommand(0)));
            buttonDownMap.Add((Buttons.LeftThumbstickUp, new JumpCommand(0)));
            buttonDownMap.Add((Buttons.LeftThumbstickDown, new CrouchCommand(0)));
            List<(Buttons, ICommand)> buttonUpMap = new List<(Buttons, ICommand)>();
            buttonUpMap.Add((Buttons.LeftThumbstickUp, new StopJumpingCommand(0)));
            buttonUpMap.Add((Buttons.LeftThumbstickDown, new StandCommand(0)));
            this.buttonDownMap = new Dictionary<Buttons, ICommand>();
            foreach ((Buttons, ICommand) keyBinding in buttonDownMap)
            {
                this.buttonDownMap.Add(keyBinding.Item1, keyBinding.Item2);
            }
            this.buttonUpMap = new Dictionary<Buttons, ICommand>();
            foreach ((Buttons, ICommand) keyBinding in buttonUpMap)
            {
                this.buttonUpMap.Add(keyBinding.Item1, keyBinding.Item2);
            }
        }
        public GamepadController((Buttons, ICommand)[] buttonDownMap, (Buttons, ICommand)[] buttonUpMap)
        {
            this.buttonDownMap = new Dictionary<Buttons, ICommand>();
            foreach ((Buttons, ICommand) keyBinding in buttonDownMap)
            {
                this.buttonDownMap.Add(keyBinding.Item1, keyBinding.Item2);
            }
            this.buttonUpMap = new Dictionary<Buttons, ICommand>();
            foreach ((Buttons, ICommand) keyBinding in buttonUpMap)
            {
                this.buttonUpMap.Add(keyBinding.Item1, keyBinding.Item2);
            }
        }

        public void Update()
        {
            foreach (KeyValuePair<Buttons, Commands.ICommand> entry in buttonDownMap)
            {
                if (GamePad.GetState(PlayerIndex.One).IsButtonDown(entry.Key))
                {
                    entry.Value.Execute();
                }
            }
            foreach (KeyValuePair<Buttons, Commands.ICommand> entry in buttonUpMap)
            {
                if(!GamePad.GetState(PlayerIndex.One).IsButtonDown(entry.Key))
                {
                    entry.Value.Execute();
                }
            }
        }
    }
}

