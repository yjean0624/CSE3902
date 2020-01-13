using Project.Sound;

namespace Project.Blocks
{
    public class EndBumpState : IBumpState
    {
        private AbstractBlock block;
        private float FALL_ACCELERATION = Config.GetGravity();
        public EndBumpState(AbstractBlock block)
        {
            this.block = block;
            this.block.Physics.yAcceleration = FALL_ACCELERATION;
        }
        public void Bump()
        {
            this.block.bumpState = new BumpState(block);
            SoundEffectManager.Instance.PlaySoundEffect(SoundEffectManager.SoundEffectTag.Bump);
        }
        public void EndBump()
        {
            //Do nothing, already end bump
        }
        public bool IsBumped()
        {
            return false;
        }
    }
}
