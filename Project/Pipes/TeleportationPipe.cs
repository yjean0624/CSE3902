using Microsoft.Xna.Framework;
using Project.Sprites;
using Project.Commands;
namespace Project.Pipes
{
    public class TeleportationPipe : AbstractPipe
    {
        protected ICommand transitionCommand;
        public TeleportationPipe(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.LargePipe);
        }
        public void Teleport()
        {
        }
    }
}
