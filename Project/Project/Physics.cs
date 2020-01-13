using Microsoft.Xna.Framework;
using Project.GameObjects;

namespace Project
{
    public class Physics : IUpdatable
    {
        public float xAcceleration { get; set; }
        public float yAcceleration { get; set; }
        public float xVelocity { get; set; }
        public float yVelocity { get; set; }
        public float xPosition { get; set; }
        public float yPosition { get; set; }
        public bool applyFriction { get; set; } = false;
        public float Friction { get; set; } = Config.GetDefaultFriction();

        public Physics(Vector2 position)
        {
            this.xAcceleration = 0;
            this.yAcceleration = Config.GetGravity();
            this.xVelocity = 0;
            this.yVelocity = 0;
            this.xPosition = position.X;
            this.yPosition = position.Y;
        }
        public Physics(Vector2 position, float xVelocity, float yVelocity)
        {
            this.xAcceleration = 0;
            this.yAcceleration = Config.GetGravity();
            this.xVelocity = xVelocity;
            this.yVelocity = yVelocity;
            this.xPosition = position.X;
            this.yPosition = position.Y;
        }
        public Physics(Vector2 position, bool applyFriction)
        {
            this.xAcceleration = 0;
            this.yAcceleration = Config.GetGravity();
            this.xVelocity = 0;
            this.yVelocity = 0;
            this.xPosition = position.X;
            this.yPosition = position.Y;
            this.applyFriction = applyFriction;
        }
        public void Update(GameTime gameTime)
        {
            float elapsedTimeInSeconds = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            xPosition = xPosition + (xVelocity * elapsedTimeInSeconds);
            yPosition = yPosition + (yVelocity * elapsedTimeInSeconds);
            xVelocity = (float)(xVelocity + (xAcceleration * elapsedTimeInSeconds));
            if (applyFriction){ xVelocity *= Friction; }
            yVelocity = yVelocity + (yAcceleration * elapsedTimeInSeconds);
        }
        public override string ToString()
        {
            return string.Format(Config.GetPhysicsToString(), xPosition, yPosition, xVelocity, yVelocity, xAcceleration, yAcceleration, applyFriction);
        }
    }
}
