using Project.GameObjects;
using Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Blocks
{
    public abstract class AbstractBlock : GameObject, IBlock
    {
        protected float maximumYPosition;
        internal IBumpState bumpState;
        internal IItemState itemState;
        protected AbstractBlock(Vector2 location) : base(location)
        {
            maximumYPosition = location.Y;
            bumpState = new EndBumpState(this);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(Physics.yPosition>maximumYPosition)
            {
                Physics.yPosition = maximumYPosition;
                Physics.yVelocity = 0;
            }
        }

        public virtual void Bump()
        {
            bumpState.Bump();
        }
        public virtual void EndBump()
        {
            bumpState.EndBump();
        }
        public virtual bool IsBumped()
        {
            return bumpState.IsBumped();
        }
    }
}
