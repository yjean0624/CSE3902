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
using Project.Camera;

namespace Project
{
    class MarioGame : Game
    {
        private SpriteBatch spriteBatch;
        private GraphicsDeviceManager graphics;
        private IController musicController;
        private HeadsUpDisplay HUD;
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
            HUD = new HeadsUpDisplay(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Textures need loaded before level
            Sprites.SpriteMachine.Instance.LoadAllTextures(Content);
            Camera.CameraController.Instance.Initialize(graphics, Content);
            GameManager.Instance.LoadLevelDictionary(Content);
            //GameManager.Instance.LoadLevel("Level1-1");
            GameManager.Instance.LoadLevelMenu(graphics.PreferredBackBufferWidth,
                                               graphics.PreferredBackBufferHeight);
            ControllerController.Instance.AddGameController(this);
            SoundEffectManager.Instance.LoadAllSoundEffects(Content);
            musicController = new MusicController();

        }

        protected override void UnloadContent()
        {
            //TODO: unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
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
