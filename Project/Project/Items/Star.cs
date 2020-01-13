using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Items
{
    class Star : Item
    {
        public Star(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.Star);
            Physics.xVelocity = 10.0f;
        }
        public void Bounce()
        {
            Physics.yVelocity = -10;
        }
    }
}
