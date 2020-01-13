using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.GameManagers
{
    //Based on a tutorial at: https://www.youtube.com/watch?v=76Mz7ClJLoE
    public class Button
    {
        public string text { get; set; }
        public SpriteFont font { get; set; }
        private bool isHovering;
        private MouseState previousMouse;
        private MouseState currentMouse;
        private int buffer = 1;
        public Vector2 Location { get; set; }
        public event EventHandler Click;
        public int Height { get { return (int)font.MeasureString(text).Y + 2 * buffer; } }
        public int Width { get { return (int)font.MeasureString(text).X + 2 * buffer; } }

        public Button(string text, SpriteFont font, Vector2 location)
        {
            this.text = text;
            this.font = font;
            this.Location = location;
            isHovering = false;
            currentMouse = Mouse.GetState();
        }
        public void Update()
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            Rectangle mouse = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);
            Rectangle button = new Rectangle((int)Location.X - buffer, 
                                             (int)Location.Y - buffer, 
                                             (int)font.MeasureString(text).X + buffer, 
                                             (int)font.MeasureString(text).Y + buffer);
            if(mouse.Intersects(button))
            {
                isHovering = true;
                if(currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
            else
            {
                isHovering = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //draw the text
            if(isHovering)
            {
                spriteBatch.DrawString(font, text, Location, Color.White);
            }
            else
            {
                spriteBatch.DrawString(font, text, Location, Color.Black);
            }
        }
    }
}
