using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Items
{
    class Star : Item
    {
        public Star(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.Star);
        }
        public void Bounce()
        {
            Physics.yVelocity = Config.GetStarBounceSpeed();
        }
    }
}
