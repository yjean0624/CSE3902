using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;


namespace Project.GameObjects
{
    public class Flagpole : GameObject, IFlagpole
    {
        public Flagpole(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.FlagPole);
            this.Physics.yAcceleration = 0;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location());
        }
    }
}

