using Microsoft.Xna.Framework;
using Project.Sprites;
using Project.Commands;

namespace Project.Pipes
{
    public class LeftFacingPipe : AbstractPipe
    {
        private Vector2 location;
        private ICommand transitionCommand;
        public LeftFacingPipe(Vector2 location) : base(location)
        {
            this.location = location;
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.LeftFacingPipe);
        }
        public void Teleport()
        {
        }
    }
}
