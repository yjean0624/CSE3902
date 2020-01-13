using Microsoft.Xna.Framework;
using Project.GameObjects;
using Project.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Enemies
{
    public class ReversedKoopaShell: GameObject
    {
        public ReversedKoopaShell(Vector2 location) : base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaShellReversed);
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
