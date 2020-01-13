using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blocks
{
    public class EmptyItemState : IItemState
    {
        private AbstractBlock block;
        public EmptyItemState(AbstractBlock block)
        {
            this.block = block;
        }
        public void ReleaseItem()
        {
            //Do nothing, it's empty
        }
    }
}
