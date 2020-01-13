using Project.Enemies;
using Project.Items;

namespace Project.Collision
{
    public class ItemEnemyCollisionHandler : AbstractCollisionHandler
    {
        public ItemEnemyCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IItem), typeof(IEnemy)), typeof(ItemEnemyCollisionResolution));
        }
    }
}
