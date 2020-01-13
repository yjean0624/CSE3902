using Microsoft.Xna.Framework;
using Project.GameObjects;
using Project.Sprites;
using System;

namespace Project.Enemies
{
    public class ReversedGoomba: GameObject
    {
        public ReversedGoomba(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.GoombaReversed);
            Physics = new Physics(location);
        }

        public override void Update(GameTime gameTime)
        {
            Physics.yVelocity = Config.GetReversedEnemyFallingSpeed();
            Physics.Update(gameTime);
            sprite.Update(gameTime);
            if (Physics.yPosition > Config.GetDespawnThreshhold())
            {
                GameManager.Instance.Remove(this);
            }
        }
}
}
