using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.GameObjects;
using Project.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BackgroundElements
{
    public class BackgroundElement : IBackgroundElement
    {
        private ISprite sprite;
        private Vector2 location;
        /*
        * This class take a sprite unlike most other game objects because 
        *this class can be many different 'objects' and the only difference
        *is the sprite.
        */
        public BackgroundElement(Vector2 location, ISprite backgroundSprite)
        {
            this.sprite = backgroundSprite;
            this.location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public Vector2 Location()
        {
            return location;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
