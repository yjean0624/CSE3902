namespace Project.GameObjects.MarioStates
{
    public class SmallMarioState : HealthMarioState
    {
        public SmallMarioState(Mario gameObject) : base(gameObject)
        {
            this.gameObject = gameObject;
        }

        public override void CollectFlower()
        {
            gameObject.SetHealthState(new FireMarioState(gameObject));
        }

        public override void CollectBrownMushroom()
        {
            gameObject.SetHealthState(new BigMarioState(gameObject));
        }

        public override void CollectStar()
        {
            GameManager.Instance.Replace(gameObject, new StarMario(gameObject.Physics, gameObject));
        }

        public override void TakeDamage()
        {
            GameManager.Instance.Replace(gameObject, new DeadMario(gameObject.Location(),gameObject));
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.MarioDie);
        }

        public override bool IsSmall()
        {
            return true;
        }
    }
}
