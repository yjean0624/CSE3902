using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Pipes
{
    public class LeftFacingPipe : AbstractPipe
    {
        private Vector2 location;
        public LeftFacingPipe(Vector2 location) : base(location)
        {
            this.location = location;
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.LeftFacingPipe);
        }
    }
}
