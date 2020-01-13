

using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Enemies.EnemyStates.KoopaState
{
    public class Koopa:AbstractEnemy
    {
        public IKoopaState state;
        public Koopa(Vector2 location) : base(location)
        {
            state = new LeftMovingKoopaState(this);
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaLeft);
            Physics.yAcceleration = Config.GetGravity();
        }

        public override void ChangeDirection()
        {
            if (state.GetType() == typeof(LeftMovingKoopaState))
            {
                state = new RightMovingKoopaState(this);
                sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaLeft);
            }
            else
            {
                state = new LeftMovingKoopaState(this);
                sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.KoopaRight);
            }
        }
    }
}
