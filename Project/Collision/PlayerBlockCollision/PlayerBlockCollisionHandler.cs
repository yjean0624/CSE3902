using Project.GameObjects;
using Project.Blocks;

namespace Project.Collision
{
    public class PlayerBlockCollisionHandler : AbstractCollisionHandler
    {
        public PlayerBlockCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IPlayer), typeof(NormalBrickBlock)), typeof(PlayerWithBrickBlockResponse));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(GroundBlock)), typeof(PlayerGroundBlockCollisionResolution));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(UndergroundBlock)), typeof(PlayerGroundBlockCollisionResolution));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(InvisibleBlock)), typeof(PlayerInvisibleBlockCollisionResolution));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(AbstractQuestionBlock)), typeof(PlayerQuestionBlockCollisionResolution));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(SolidBlock)), typeof(PlayerSolidBlockCollisionResolution));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(StairBlock)), typeof(PlayerStairBlockCollisionResolution));
        }
    }
}
