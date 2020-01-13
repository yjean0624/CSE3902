using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Pipes
{
    public class PipeHalf : MediumPipe
    {
        private Vector2 location;
        public PipeHalf(Vector2 location) : base(location)
        {
            this.location = location;
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.PipeHalf);
        }
    }
}
