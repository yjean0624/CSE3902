using Project.Items;

namespace Project.Collision
{
    public class ItemItemCollisionHandler : AbstractCollisionHandler
    {
        public ItemItemCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IItem), typeof(IItem)), typeof(PushableBlockPushableBlockCollisionResolution));
        }
    }
}
