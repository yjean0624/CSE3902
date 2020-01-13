using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Project.Collision;
using Project.Commands;
using Project.Controllers;
using Project.GameObjects;
using Project.Levels;
using Project.Sound;
using System.Collections.Generic;

namespace Project
{
    class MarioGame : Game
    {
        private SpriteBatch spriteBatch;
        private GraphicsDeviceManager graphics;
        private IController keyboardController;
        private IController gamepadController;
        private IController musicController;
        private Camera.ICamera camera;
        public MarioGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = Config.GetDefaultWindowHeight();
            graphics.PreferredBackBufferWidth = Config.GetDefaultWindowWidth();
            Content.RootDirectory = Config.GetRootDirectory();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Textures need loaded before level
            Sprites.SpriteMachine.Instance.LoadAllTextures(Content);
            GameManager.Instance.LoadLevelDictionary(Content);
            GameManager.Instance.LoadFirstLevel(Content);
            SoundEffectManager.Instance.LoadAllSoundEffects(Content);
            SoundEffectManager.Instance.PlayBGM();
            camera = new Camera.PlayerFollowingCamera(0);
            keyboardController = new KeyboardController(this);
            gamepadController = new GamepadController(this);
            musicController = new MusicController();
            HeadsUpDisplay.Instance.LoadAllFonts(Content);
        }

        protected override void UnloadContent()
        {
            //TODO: unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardController.Update();
            gamepadController.Update();
            musicController.Update();
            GameManager.Instance.Update(gameTime, Content);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GameManager.Instance.Draw(spriteBatch, 
                        gameTime, 
                        graphics.PreferredBackBufferWidth, 
                        graphics.PreferredBackBufferHeight);
            base.Draw(gameTime);
        }
        public GraphicsDeviceManager GetGraphicsDevice()
        {
            return this.graphics;
        }
    }
}
