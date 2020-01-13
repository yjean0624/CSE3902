using Project.GameObjects;
using Project.Enemies;

namespace Project.Collision

{
    public class PlayerEnemyCollisionHandler : AbstractCollisionHandler
    {
        public PlayerEnemyCollisionHandler()
        {
            collisionResolutionMap.Add((typeof(IPlayer), typeof(Goomba)), typeof(PlayerWithGoomba));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(Koopa)), typeof(PlayerWithKoopa));
            collisionResolutionMap.Add((typeof(IPlayer), typeof(KoopaShell)), typeof(PlayerWithKoopaShell));
        }
    }
}
