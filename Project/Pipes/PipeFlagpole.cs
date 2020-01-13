using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Pipes
{
    public class PipeFlagpole : MediumPipe
    {
        private Vector2 location;
        public PipeFlagpole(Vector2 location) : base(location)
        {
            this.location = location;
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.PipeFlagpole);
        }
    }
}
