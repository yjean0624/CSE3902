using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;


namespace Project.GameObjects
{
    public class Flag : GameObject
    {
        public Flag(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.Flag);
            this.Physics.yAcceleration = 0;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location());
        }
    }
}

