namespace Project.Blocks
{
    public abstract class AbstractItemState : IItemState
    {
        protected AbstractBlock block;
        public AbstractItemState(AbstractBlock block)
        {
            this.block = block;
        }
        public abstract void ReleaseItem();
    }
}
