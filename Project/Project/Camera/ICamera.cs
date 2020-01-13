using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Camera
{
    interface ICamera
    {
        void Draw(SpriteBatch spriteBatch, GameTime gameTime, float screenWidth, float screenHeight);
    }
}
