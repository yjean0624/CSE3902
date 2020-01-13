using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Enemies
{
    public class Goomba : Enemy
    {
        public Goomba(Vector2 location): base(location)
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.Goomba);
            Physics = new Physics(location);
            Physics.xVelocity = Config.GetEnemyMovingSpeed();
        }

        public override void Fall()
        {
            ReversedGoomba reversedGoomba = new ReversedGoomba(this.Location());
            GameManager.Instance.Replace(this, reversedGoomba);
        }
    }
}