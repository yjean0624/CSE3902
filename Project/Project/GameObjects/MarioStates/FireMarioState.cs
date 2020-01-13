using Microsoft.Xna.Framework;
namespace Project.GameObjects.MarioStates
{
    public class FireMarioState : HealthMarioState
    {
        public FireballThrowingState fireballThrowingState;
        public FireMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
            fireballThrowingState = new ThrowingFireballState(this);
        }
        public override void CollectFlower()
        {
            //do nothing
        }

        public override void CollectBrownMushroom()
        {
            //do nothing
        }

        public override void CollectStar()
        {
            //TODO: Replace gameObject with a new StarMario in the Level object
        }

        public override void TakeDamage()
        {
            gameObject.SetHealthState(new SmallMarioState(gameObject));
        }

        public override void ThrowFireball(Vector2 location, Vector2 velocity)
        {
            fireballThrowingState.ThrowFireball(location, velocity);
        }

        public override void StopThrowingFireball()
        {
            fireballThrowingState.StopThrowingFireball();
        }

        public override bool IsFire()
        {
            return true;
        }
    }
}
