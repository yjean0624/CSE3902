using Project.Items;
using Project.Pipes;

namespace Project.Collision
{
    public class ItemPipeCollisionHandler : AbstractCollisionHandler
    {
        public ItemPipeCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(Item), typeof(IPipe)), typeof(ItemPipeCollisionResolution));
        }
    }
}
