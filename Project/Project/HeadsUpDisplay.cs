using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.GameObjects;
using Project.Sprites;

namespace Project
{
    public sealed class HeadsUpDisplay
    {
        private SpriteFont font;

        public static HeadsUpDisplay Instance = new HeadsUpDisplay();

        public HeadsUpDisplay()
        {
        }

        public void LoadAllFonts(ContentManager content)
        {
            font = content.Load<SpriteFont>("font");
        }

        public string ConvertToString(int num, int formatDigit)
        {
            string str = num.ToString();
            while(str.Length < formatDigit)
            {
                str = "0" + str;
            }
            return str;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "MARIO",  new Vector2(150, 10), Color.White);
            spriteBatch.DrawString(font, Instance.ConvertToString(GameManager.Instance.GetScore(), 6), new Vector2(150, 40), Color.White);
            SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.Coin).Draw(spriteBatch, new Vector2(332, 45));
            spriteBatch.DrawString(font, "x" + Instance.ConvertToString(GameManager.Instance.coinsCollected, 2), new Vector2(350, 40), Color.White);
            spriteBatch.DrawString(font, "WORLD", new Vector2(450, 10), Color.White);
            spriteBatch.DrawString(font, "1-1", new Vector2(466, 40), Color.White);
            spriteBatch.DrawString(font, "TIME", new Vector2(600, 10), Color.White);
            spriteBatch.DrawString(font, GameManager.Instance.GetSecondsLeft().ToString(), new Vector2(600, 40), Color.White);
            spriteBatch.DrawString(font, "LIVES", new Vector2(750, 10), Color.White);
            spriteBatch.DrawString(font, "" + ((IMario)GameManager.Instance.GetMarios()[0]).GetLives(), new Vector2(780, 40), Color.White);
            spriteBatch.End();
        }

    }
}
