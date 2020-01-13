using Project.Blocks;
using Project.Enemies;
using Project.Items;
using Project.Pipes;
using Project.GameObjects;
using Project.Collision.EnemyEnemyCollision;

namespace Project.Collision
{
    public class GeneralCollisionHandler : AbstractCollisionHandler
    {
        public GeneralCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IPlayer), typeof(IBlock)), typeof(PlayerBlockCollisionHandler));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(IEnemy)), typeof(PlayerEnemyCollisionHandler));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(IItem)), typeof(PlayerItemCollisionHandler));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(IPipe)), typeof(PlayerPipeCollisionHandler));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(Flagpole)), typeof(PlayerFlagpoleCollisionHandler));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(IPlayer)), typeof(PlayerPlayerCollisionHandler));
            collisionResolutionMap.Add((typeof(IEnemy), typeof(IBlock)), typeof(EnemyBlockCollisionHandler));
            collisionResolutionMap.Add((typeof(IItem), typeof(IBlock)), typeof(ItemBlockCollisionHandler));
            collisionResolutionMap.Add((typeof(IItem), typeof(IItem)), typeof(ItemItemCollisionHandler));
            collisionResolutionMap.Add((typeof(IItem), typeof(IEnemy)), typeof(ItemEnemyCollisionHandler));
            collisionResolutionMap.Add((typeof(IEnemy), typeof(IEnemy)), typeof(EnemyEnemyCollisionHandler));
            collisionResolutionMap.Add((typeof(IEnemy), typeof(Fireball)), typeof(EnemyFireballCollisionHandler));
            collisionResolutionMap.Add((typeof(IEnemy), typeof(IPipe)), typeof(EnemyPipeCollisionHandler));
            collisionResolutionMap.Add((typeof(IProjectile), typeof(IBlock)), typeof(FireballBlockCollisionHandler));
            collisionResolutionMap.Add((typeof(IProjectile), typeof(IPipe)), typeof(FireballPipeCollisionHandler));
            collisionResolutionMap.Add((typeof(IItem), typeof(IPipe)), typeof(ItemPipeCollisionHandler));
        }
    }
}
