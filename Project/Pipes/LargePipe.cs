using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Pipes
{
    public class LargePipe : AbstractPipe
    {
        private Vector2 location;
        public LargePipe(Vector2 location) : base(location)
        {
            this.location = location;
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.LargePipe);
        }
    }
}
