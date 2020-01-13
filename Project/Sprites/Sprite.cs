using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites
{
    class Sprite : ISprite
    {
        private Texture2D texture;
        private int animationPosition;
        private List<Frame> frameList;
        private float framesPerSecond;
        private float secondsSinceLastFrame;
        public Sprite(Texture2D texture, List<Frame> frameList, float framesPerSecond)
        {
            this.animationPosition = 0;
            this.texture = texture;
            this.frameList = frameList;
            this.framesPerSecond = framesPerSecond;
            secondsSinceLastFrame = 0.0f;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(frameList[animationPosition].GetX(), 
                                                      frameList[animationPosition].GetY(),
                                                      frameList[animationPosition].GetWidth(),
                                                      frameList[animationPosition].GetHeight());
            spriteBatch.Draw(texture, location, sourceRectangle, Color.White);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle = new Rectangle(frameList[animationPosition].GetX(),
                                                      frameList[animationPosition].GetY(),
                                                      frameList[animationPosition].GetWidth(),
                                                      frameList[animationPosition].GetHeight());
            spriteBatch.Draw(texture, location, sourceRectangle, color);
        }

        public int GetHeight()
        {
            return frameList[animationPosition].GetHeight();
        }

        public int GetWidth()
        {
            return frameList[animationPosition].GetWidth();
        }

        public void Update(GameTime gameTime)
        {
            secondsSinceLastFrame += ((float)gameTime.ElapsedGameTime.Milliseconds) / 1000;
            if (secondsSinceLastFrame > 1.0f / framesPerSecond)
            {
                secondsSinceLastFrame -= 1.0f / framesPerSecond;
                animationPosition++;
                if (animationPosition >= frameList.Count)
                {
                    animationPosition = 0;
                }
            }
        }

    }
}
