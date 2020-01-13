using Project.Levels;
using Project.Items;
using Microsoft.Xna.Framework;

namespace Project.Blocks
{
    public class BrownMushroomState : AbstractItemState
    {
        public BrownMushroomState(AbstractBlock block) : base(block)
        {
            this.block = block;
        }
        public override void ReleaseItem()
        {
            BrownMushroom brownMushroom = new BrownMushroom(new Vector2(this.block.Location().X, this.block.Location().Y - this.block.GetHitBox().Height));
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.PowerUpAppears);
            GameManager.Instance.AddToCollidables(brownMushroom);
            brownMushroom.Physics.xVelocity = Config.GetItemMovementSpeed();
            block.itemState = new EmptyItemState(block);
        }
    }
}
