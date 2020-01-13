using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Items
{
    public class SpeedBoostItem : Item
    {
        public SpeedBoostItem(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.SpeedBoostItem);
            Physics.xVelocity = 0.0f;
        }
    }
}
