using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Pipes
{
    public class MediumPipe : AbstractPipe
    { 
        public MediumPipe(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.MediumPipe);
        }
    }
}
