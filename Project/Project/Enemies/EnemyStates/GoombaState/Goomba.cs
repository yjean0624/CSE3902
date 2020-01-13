using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Enemies.EnemyStates
{
    public class Goomba: AbstractEnemy
    {
        public IGoombaState state;
        public Goomba(Vector2 location) :base(location)
        {
            state = new LeftMovingGoombaState(this);
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.Goomba);
            Physics = new Physics(location);
            Physics.yAcceleration = Config.GetGravity();
        }

        public void BeStomped()
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.DeadGoomba);
            state.BeStomped();
        }

        public void BeFlipped()
        {
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.GoombaReversed);
            state.BeFlipped();
        }
    }
}
