using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Pipes
{
    public class SmallPipe : AbstractPipe
    {
        private Vector2 location;
        public SmallPipe(Vector2 location) : base(location)
        {
            this.location = location;
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.SmallPipe);
        }
    }
}
