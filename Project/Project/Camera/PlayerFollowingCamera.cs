using Microsoft.Xna.Framework;
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

        private float zoom = Config.GetCameraZoom();
        private float downwardOffset = Config.GetDownwardOffset();
        private int playerIndex;
        public PlayerFollowingCamera(int playerIndex)
        {
            this.playerIndex = playerIndex;
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, float viewWidth, float viewHeight)
        {
            Matrix transformation = GetTransformation(GameManager.Instance.GetMarios()[playerIndex], viewWidth, viewHeight);
            
            spriteBatch.Begin(transformMatrix: transformation);
            foreach(IGameObject next in GameManager.Instance.GetAllObjects())
            {
                next.Draw(spriteBatch);
            }
            spriteBatch.End();
            HeadsUpDisplay.Instance.Draw(spriteBatch);
        }
        private Matrix GetTransformation(GameObjects.GameObject gameObject, float viewWidth, float viewHeight)
        {
            Matrix transformation;
            Matrix position = Matrix.CreateTranslation(
                -gameObject.Location().X, -downwardOffset, 0);
            Matrix offset = Matrix.CreateTranslation(viewWidth / 2, 0, 0);
            Matrix zoom = Matrix.CreateScale(this.zoom, this.zoom, 1);
            transformation = position * zoom * offset;
            return transformation;
        }
    }
}
