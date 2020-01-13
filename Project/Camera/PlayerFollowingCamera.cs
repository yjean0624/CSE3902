using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.GameObjects;
using Project.Levels;

namespace Project.Camera
{
    //Based on tutorial at: https://www.youtube.com/watch?v=ceBCDKU_mNw
    //and at:
    //https://roguesharp.wordpress.com/2014/07/13/tutorial-5-creating-a-2d-camera-with-pan-and-zoom-in-monogame/
    //I only understand the Matrix math enough to make it work -Derek
    public class PlayerFollowingCamera : ICamera
    {
        private int playerIndex;
        private HeadsUpDisplay HUD;
        private int interval;
        public PlayerFollowingCamera(int playerIndex, ContentManager content)
        {
            this.playerIndex = playerIndex;
            HUD = new HeadsUpDisplay(content);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, float viewWidth, float viewHeight, float zoom, float downwardOffset)
        {
            Matrix transformation = GetTransformation(GameManager.Instance.GetMarios()[playerIndex], viewWidth, viewHeight, zoom, downwardOffset);
            
            spriteBatch.Begin(transformMatrix: transformation);
            foreach(IGameObject next in GameManager.Instance.GetAllObjectsInDrawOrder())
            {
                next.Draw(spriteBatch);
            }
            spriteBatch.End();
            interval = (int)viewWidth / 4;
            HUD.Draw(spriteBatch, interval);
        }
        private Matrix GetTransformation(GameObjects.GameObject gameObject, float viewWidth, float viewHeight, float zoom, float downwardOffset)
        {
            Matrix transformation;
            Matrix position = Matrix.CreateTranslation(
                -gameObject.Location().X, -downwardOffset, 0);
            Matrix offset = Matrix.CreateTranslation(viewWidth / 2, 0, 0);
            Matrix Mzoom = Matrix.CreateScale(zoom, zoom, 1);
            transformation = position * Mzoom * offset;
            return transformation;
        }
    }
}
