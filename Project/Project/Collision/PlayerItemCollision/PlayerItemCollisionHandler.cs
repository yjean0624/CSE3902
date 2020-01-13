using Project.GameObjects;
using Project.Items;


namespace Project.Collision
{
    public class PlayerItemCollisionHandler : AbstractCollisionHandler
    {
        public PlayerItemCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IPlayer), typeof(BrownMushroom)), typeof(PlayerBrownMushroomCollisionResolution));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(StaticCoin)), typeof(PlayerCoinCollisionResolution));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(Flower)), typeof(PlayerFlowerCollisionResolution));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(SpeedBoostItem)), typeof(PlayerGreenMushroomCollisionResolution));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(Star)), typeof(PlayerStarCollisionResolution));
        }
    }
}
