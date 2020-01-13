using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;

namespace Project.Pipes
{
    public abstract class AbstractPipe : GameObjects.GameObject, IPipe
    {
        public AbstractPipe(Vector2 location):base(location)
        {
            this.sprite = sprite;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
