using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Project.Controllers
{
    public sealed class ControllerController
    {
        public static ControllerController Instance { get; } = new ControllerController();
        private Dictionary<GameManager.PlayerTag, IController> playerControllers = new Dictionary<GameManager.PlayerTag, IController>();
        private IController gameController;
        private (List<(Keys, Type)>, List<(Keys, Type)>) firstPlayerKeyBindings;
        private (List<(Keys, Type)>, List<(Keys, Type)>) secondPlayerKeyBindings;
        private (List<(Keys, Type)>, List<(Keys, Type)>) thirdPlayerKeyBindings;
        private (List<(Buttons, Type)>, List<(Buttons, Type)>) fourthPlayerButtonBindings;
        private ControllerController()
        {
            List<(Keys, Type)> keyDownBindings = new List<(Keys, Type)>();
            List<(Keys, Type)> keyUpBindings = new List<(Keys, Type)>();

            keyDownBindings.Add((Keys.A, typeof(MoveLeftCommand)));
            keyDownBindings.Add((Keys.D, typeof(MoveRightCommand)));
            keyDownBindings.Add((Keys.W, typeof(JumpCommand)));
            keyDownBindings.Add((Keys.S, typeof(CrouchCommand)));
            keyDownBindings.Add((Keys.LeftShift, typeof(ThrowFireballCommand)));
            keyUpBindings.Add((Keys.W, typeof(StopJumpingCommand)));
            keyUpBindings.Add((Keys.LeftShift, typeof(StopThrowingFireballCommand)));
            keyUpBindings.Add((Keys.S, typeof(StandCommand)));
            firstPlayerKeyBindings = (keyDownBindings, keyUpBindings);

            keyDownBindings = new List<(Keys, Type)>();
            keyUpBindings = new List<(Keys, Type)>();
            keyDownBindings.Add((Keys.J, typeof(MoveLeftCommand)));
            keyDownBindings.Add((Keys.L, typeof(MoveRightCommand)));
            keyDownBindings.Add((Keys.I, typeof(JumpCommand)));
            keyUpBindings.Add((Keys.I, typeof(StopJumpingCommand)));
            keyDownBindings.Add((Keys.K, typeof(CrouchCommand)));
            keyUpBindings.Add((Keys.K, typeof(StandCommand)));
            keyDownBindings.Add((Keys.Space, typeof(ThrowFireballCommand)));
            keyUpBindings.Add((Keys.Space, typeof(StopThrowingFireballCommand)));
            secondPlayerKeyBindings = (keyDownBindings, keyUpBindings);

            keyDownBindings = new List<(Keys, Type)>();
            keyUpBindings = new List<(Keys, Type)>();
            keyDownBindings.Add((Keys.Left, typeof(MoveLeftCommand)));
            keyDownBindings.Add((Keys.Right, typeof(MoveRightCommand)));
            keyDownBindings.Add((Keys.Up, typeof(JumpCommand)));
            keyUpBindings.Add((Keys.Up, typeof(StopJumpingCommand)));
            keyDownBindings.Add((Keys.Down, typeof(CrouchCommand)));
            keyUpBindings.Add((Keys.Down, typeof(StandCommand)));
            keyDownBindings.Add((Keys.RightShift, typeof(ThrowFireballCommand)));
            keyUpBindings.Add((Keys.RightShift, typeof(StopThrowingFireballCommand)));
            thirdPlayerKeyBindings = (keyDownBindings, keyUpBindings);

            List<(Buttons, Type)> buttonDownBindings = new List<(Buttons, Type)>();
            List<(Buttons, Type)> buttonUpBindings = new List<(Buttons, Type)>();

            buttonDownBindings.Add((Buttons.DPadLeft, typeof(MoveLeftCommand)));
            buttonDownBindings.Add((Buttons.DPadRight, typeof(MoveRightCommand)));
            buttonDownBindings.Add((Buttons.A, typeof(JumpCommand)));
            buttonUpBindings.Add((Buttons.A, typeof(StopJumpingCommand)));
            buttonDownBindings.Add((Buttons.DPadDown, typeof(CrouchCommand)));
            buttonUpBindings.Add((Buttons.DPadDown, typeof(StandCommand)));
            buttonDownBindings.Add((Buttons.RightTrigger, typeof(ThrowFireballCommand)));
            buttonUpBindings.Add((Buttons.RightTrigger, typeof(StopThrowingFireballCommand)));
            fourthPlayerButtonBindings = (buttonDownBindings, buttonUpBindings);
        }
        public void AddGameController(Game game)
        {
            List<(Keys, ICommand)> keyDownCommands = new List<(Keys, ICommand)>();
            List<(Keys, ICommand)> keyUpCommands = new List<(Keys, ICommand)>();
            keyDownCommands.Add((Keys.Q, new ExitCommand(game)));
            keyDownCommands.Add((Keys.M, new PauseCommand()));
            keyDownCommands.Add((Keys.N, new UnpauseCommand()));
            gameController = new KeyboardController(keyDownCommands.ToArray(), keyUpCommands.ToArray());
        }
        public void AddPlayerController(GameManager.PlayerTag tag)
        {
            switch(playerControllers.Count)
            {
                case 0:
                    this.AddFirstPlayerController(tag);
                    break;
                case 1:
                    this.AddSecondPlayerController(tag);
                    break;
                case 2:
                    this.AddThirdPlayerController(tag);
                    break;
                case 3:
                    this.AddFourthPlayerController(tag);
                    break;
            }
        }
        public void RemoveAllControllers()
        {
            gameController = null;
            playerControllers = new Dictionary<GameManager.PlayerTag, IController>();
        }
        public void RemoveGameController()
        {
            gameController = null;
        }
        public void RemovePlayerController(GameManager.PlayerTag tag)
        {
            playerControllers.Remove(tag);
        }
        public void RemoveAllPlayerControllers()
        {
            playerControllers.Clear();
        }
        public void Update()
        {
            if(gameController != null)
            {
                gameController.Update();
            }
            foreach(IController controller in playerControllers.Values)
            {
                controller.Update();
            }
        }
        public void UpdateGameController()
        {
            if (gameController != null)
            {
                gameController.Update();
            }
        }
        private void AddFirstPlayerController(GameManager.PlayerTag tag)
        {
            List<(Keys, ICommand)> keyDownCommands = new List<(Keys, ICommand)>();
            foreach ((Keys, Type) binding in firstPlayerKeyBindings.Item1)
            {
                AddKeyBindingToList(binding, keyDownCommands, tag);
            }
            List<(Keys, ICommand)> keyUpCommands = new List<(Keys, ICommand)>();
            foreach ((Keys, Type) binding in firstPlayerKeyBindings.Item2)
            {
                AddKeyBindingToList(binding, keyUpCommands, tag);
            }
            playerControllers.Add(tag, new KeyboardController(keyDownCommands.ToArray(), keyUpCommands.ToArray()));
        }
        private void AddSecondPlayerController(GameManager.PlayerTag tag)
        {
            List<(Keys, ICommand)> keyDownCommands = new List<(Keys, ICommand)>();
            foreach ((Keys, Type) binding in secondPlayerKeyBindings.Item1)
            {
                AddKeyBindingToList(binding, keyDownCommands, tag);
            }
            List<(Keys, ICommand)> keyUpCommands = new List<(Keys, ICommand)>();
            foreach ((Keys, Type) binding in secondPlayerKeyBindings.Item2)
            {
                AddKeyBindingToList(binding, keyUpCommands, tag);
            }
            playerControllers.Add(tag, new KeyboardController(keyDownCommands.ToArray(), keyUpCommands.ToArray()));
        }
        private void AddThirdPlayerController(GameManager.PlayerTag tag)
        {
            List<(Keys, ICommand)> keyDownCommands = new List<(Keys, ICommand)>();
            foreach ((Keys, Type) binding in thirdPlayerKeyBindings.Item1)
            {
                AddKeyBindingToList(binding, keyDownCommands, tag);
            }
            List<(Keys, ICommand)> keyUpCommands = new List<(Keys, ICommand)>();
            foreach ((Keys, Type) binding in thirdPlayerKeyBindings.Item2)
            {
                AddKeyBindingToList(binding, keyUpCommands, tag);
            }
            playerControllers.Add(tag, new KeyboardController(keyDownCommands.ToArray(), keyUpCommands.ToArray()));
        }
        private void AddFourthPlayerController(GameManager.PlayerTag tag)
        {
            List<(Buttons, ICommand)> buttonDownCommands = new List<(Buttons, ICommand)>();
            foreach ((Buttons, Type) binding in fourthPlayerButtonBindings.Item1)
            {
                AddButtonBindingToList(binding, buttonDownCommands, tag);
            }
            List<(Buttons, ICommand)> buttonUpCommands = new List<(Buttons, ICommand)>();
            foreach ((Buttons, Type) binding in fourthPlayerButtonBindings.Item2)
            {
                AddButtonBindingToList(binding, buttonUpCommands, tag);
            }
            playerControllers.Add(tag, new GamepadController(buttonDownCommands.ToArray(), buttonUpCommands.ToArray()));
        }
        private void AddKeyBindingToList((Keys, Type) binding, List<(Keys, ICommand)> bindings, GameManager.PlayerTag tag)
        {
            ConstructorInfo commandConstructor = binding.Item2.GetConstructors()[0];
            object[] parameters = { tag };
            ICommand command = (ICommand)commandConstructor.Invoke(parameters);
            bindings.Add((binding.Item1, command));
        }
        private void AddButtonBindingToList((Buttons, Type) binding, List<(Buttons, ICommand)> bindings, GameManager.PlayerTag tag)
        {
            ConstructorInfo commandConstructor = binding.Item2.GetConstructors()[0];
            object[] parameters = { tag };
            ICommand command = (ICommand)commandConstructor.Invoke(parameters);
            bindings.Add((binding.Item1, command));
        }
    }
}