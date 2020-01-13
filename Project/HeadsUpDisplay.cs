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
        public HeadsUpDisplay(ContentManager content)
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

        public void Draw(SpriteBatch spriteBatch, int interval)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "MARIO", new Vector2(interval, 10), Color.White);
            spriteBatch.DrawString(font, ConvertToString(GameManager.Instance.GetScore(), 6), new Vector2(interval, 40), Color.White);
            spriteBatch.DrawString(font, "WORLD", new Vector2(2*interval, 10), Color.White);
            spriteBatch.DrawString(font, GameManager.Instance.GetCurrentLevelName(), new Vector2(2*interval, 40), Color.White);
            spriteBatch.DrawString(font, "TIME", new Vector2(3*interval, 10), Color.White);
            spriteBatch.DrawString(font, GameManager.Instance.GetSecondsElapsed().ToString(), new Vector2(3*interval, 40), Color.White);spriteBatch.End();
        }

    }
}
