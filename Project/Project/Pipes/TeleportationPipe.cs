using Microsoft.Xna.Framework;
using Project.Sprites;
namespace Project.Pipes
{
    public class TeleportationPipe : AbstractPipe
    {
        public TeleportationPipe(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.LargePipe);
        }
        public void Teleport()
        {
            throw new System.NotImplementedException();
        }
    }
}
