using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Blocks
{
    public class BumpState : IBumpState
    {
        private AbstractBlock block;
        public BumpState(AbstractBlock block)
        {
            this.block = block;
            this.block.Physics.yVelocity = -200f;
        }
        public void Bump()
        {
            //Do nothing, already bumped
        }
        public void EndBump()
        {
            this.block.bumpState = new EndBumpState(this.block);
        }
        public bool IsBumped()
        {
            return true;
        }
    }
}
