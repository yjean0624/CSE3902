using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Camera
{
    public sealed class CameraController
    {
        public static CameraController Instance { get; } = new CameraController();

        private List<ICamera> cameras;

        private CameraController()
        {
            cameras = new List<ICamera>();
        }
        public void AddCameraFollowingMario(int marioIndex)
        {
            cameras.Add(new PlayerFollowingCamera(marioIndex));
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, float screenWidth, float screenHeight)
        {
            foreach(ICamera camera in cameras)
            {
                camera.Draw(spriteBatch,gameTime,screenWidth,screenHeight);
            }
        }
    }
}
