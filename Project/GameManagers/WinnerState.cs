using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Sprites;

namespace Project.GameManagers
{
    public class WinnerState : IGameState
    {
        private List<Button> buttons;
        private ContentManager content;
        private float screenWidth;
        private readonly int distanceBetweenButtons = 10;
        private ISprite mouseCursor;
        private string[] levelNames;
        public WinnerState(string winner, ContentManager content, float screenWidth, string[] levelNames)
        {
            Sound.SoundEffectManager.Instance.StopBackgroudMusic();
            this.content = content;
            this.screenWidth = screenWidth;
            this.levelNames = levelNames;
            SpriteFont font = content.Load<SpriteFont>("font");
            mouseCursor = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.MouseCursor);
            buttons = new List<Button>();
            int nextYPosition = distanceBetweenButtons;
            buttons.Add(new Button(winner + " WINS!", font, new Vector2(0, 0)));
            int x = (int)(screenWidth / 2)  - (buttons[buttons.Count - 1].Width / 2);
            buttons[buttons.Count - 1].Location = new Vector2(x, nextYPosition);
            buttons[buttons.Count - 1].Click += Button_Click;
            nextYPosition += buttons[buttons.Count - 1].Height + distanceBetweenButtons;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            GameManager.Instance.GameState = new LevelMenuState(levelNames, content, screenWidth);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, float screenWidth, float screenHeight)
        {
            spriteBatch.Begin();
            foreach(Button button in buttons)
            {
                button.Draw(spriteBatch);
            }
            mouseCursor.Draw(spriteBatch, new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
            spriteBatch.End();
        }

        public bool IsPaused()
        {
            return false;
        }

        public void Pause()
        {
            //do nothing
        }

        public void Unpause()
        {
            //do nothing
        }

        public void Update(GameTime gameTime, ContentManager content)
        {
            foreach(Button button in buttons)
            {
                button.Update();
            }
        }
    }
}
