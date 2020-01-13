using Microsoft.Xna.Framework;
using Project.Sprites;


namespace Project.Items
{
    public class PushableBlock : Item
    {
        public PushableBlock(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.StairBlock);
            Physics.applyFriction = true;
            Physics.yAcceleration = 0;
        }
        public override void Collect()
        { }
    }
}
