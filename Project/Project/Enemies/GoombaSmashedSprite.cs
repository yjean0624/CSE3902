using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Enemies
{
    class GoombaSmashedSprite : IEnemy
    {
        public Texture2D Texture { get; set; }

        public GoombaSmashedSprite(Texture2D goombaSpritesheet)
        {
            Texture = goombaSpritesheet;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(Texture, location, Color.White);
        }


        public void Update(GameTime gameTime)
        {
           
        }
    }
}
