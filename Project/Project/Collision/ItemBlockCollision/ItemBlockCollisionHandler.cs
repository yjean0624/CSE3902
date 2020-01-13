using Project.Items;
using Project.Blocks;

namespace Project.Collision
{
    public class ItemBlockCollisionHandler : AbstractCollisionHandler
    {
        public ItemBlockCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IItem), typeof(IBlock)), typeof(ItemBlockCollisionResolution));
        }
    }
}
