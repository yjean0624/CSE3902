namespace Project.GameObjects.MarioStates
{
    public class BigMarioState : HealthMarioState
    {
        public BigMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
        }

        public override void CollectFlower()
        {
            gameObject.SetHealthState(new FireMarioState(gameObject));
        }

        public override void CollectBrownMushroom()
        {
            //do nothing
        }

        public override void CollectStar()
        {
            //TODO: Replace gameObject with a new StarMarioMp3 in the Level object
        }

        public override void TakeDamage()
        {
            gameObject.SetHealthState(new SmallMarioState(gameObject));
        }

        public override bool IsBig()
        {
            return true;
        }
    }
}
