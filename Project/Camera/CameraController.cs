using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;
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
        private List<Viewport> viewports;
        private GraphicsDeviceManager graphics;
        private ContentManager content;
        private Viewport defaultView;
        public Viewport firstView;
        public Viewport secondView;
        public Viewport thirdView;
        public Viewport fourthView;
        private float zoom = Config.GetCameraZoom();
        private float oneStoreyDownwardOffset = Config.GetOneStoreyDownwardOffset();
        private float twoStoreyDownwardOffset = Config.GetTwoStoreyDownwardOffset();

        private CameraController()
        {
            cameras = new List<ICamera>();
            viewports = new List<Viewport>();
        }

        public void Initialize(GraphicsDeviceManager graphics, ContentManager content)
        {
            this.graphics = graphics;
            this.content = content;
            defaultView = graphics.GraphicsDevice.Viewport;
        }

        public void AddCameraFollowingMario(int marioIndex)
        {
            cameras.Add(new PlayerFollowingCamera(marioIndex, content));
        }
        public void RemoveAllCameras()
        {
            cameras.Clear();
            viewports.Clear();
        }

        public void AddViewports(int numberOfPlayers)
        {
            if (numberOfPlayers == 1)
            {
                firstView = defaultView;
                viewports.Add(firstView);
            }
            if (numberOfPlayers == 2)
            {
                firstView = defaultView;
                secondView = defaultView;
                firstView.Height = defaultView.Height / 2;
                secondView.Height = defaultView.Height / 2;
                secondView.Y = firstView.Height;
                viewports.Add(firstView);
                viewports.Add(secondView);
            }
            if(numberOfPlayers == 3)
            {
                firstView = defaultView;
                secondView = defaultView;
                thirdView = defaultView;
                firstView.Width = defaultView.Width / 2;
                secondView.Width = defaultView.Width / 2;
                secondView.X = firstView.Width;
                firstView.Height = defaultView.Height / 2;
                secondView.Height = defaultView.Height / 2;
                thirdView.Width = defaultView.Width / 2;
                thirdView.Height = defaultView.Height / 2;
                thirdView.Y = firstView.Height;
                viewports.Add(firstView);
                viewports.Add(secondView);
                viewports.Add(thirdView);
            }
            if(numberOfPlayers == 4)
            {
                firstView = defaultView;
                secondView = defaultView;
                thirdView = defaultView;
                fourthView = defaultView;
                firstView.Width = defaultView.Width / 2;
                secondView.Width = defaultView.Width / 2;
                secondView.X = firstView.Width;
                firstView.Height = defaultView.Height / 2;
                secondView.Height = defaultView.Height / 2;
                thirdView.Width = defaultView.Width / 2;
                fourthView.Width = defaultView.Width / 2;
                fourthView.X = thirdView.Width;
                thirdView.Height = defaultView.Height / 2;
                fourthView.Height = defaultView.Height / 2;
                thirdView.Y = firstView.Height;
                fourthView.Y = secondView.Height;
                viewports.Add(firstView);
                viewports.Add(secondView);
                viewports.Add(thirdView);
                viewports.Add(fourthView);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, float screenWidth, float screenHeight)
        {
            int views = viewports.Count();
            foreach (var cameraViewport in cameras.Zip(viewports, Tuple.Create))
            {
                graphics.GraphicsDevice.Viewport = cameraViewport.Item2;
                if (views > 2)
                {
                    cameraViewport.Item1.Draw(spriteBatch, gameTime, screenWidth / 2, screenHeight / 2, zoom, twoStoreyDownwardOffset);
                }
                else if(views == 2)
                {
                    cameraViewport.Item1.Draw(spriteBatch, gameTime, screenWidth, screenHeight / 2, zoom, oneStoreyDownwardOffset);
                }
                else
                {
                    cameraViewport.Item1.Draw(spriteBatch, gameTime, screenWidth, screenHeight, zoom, oneStoreyDownwardOffset);
                }
            }
            graphics.GraphicsDevice.Viewport = defaultView;
        }
    }
}
