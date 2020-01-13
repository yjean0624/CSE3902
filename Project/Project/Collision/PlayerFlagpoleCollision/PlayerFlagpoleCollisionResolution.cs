using Project.Collision;
using Project.GameObjects;
using System;
using Project.Sound;

namespace Project.Collision
{
    public class PlayerFlagpoleCollisionResolution : ICollisionHandler
    {
        public PlayerFlagpoleCollisionResolution()
        {
        }
        public void Handle(ICollidable player, ICollidable flagpole, CollisionDirection.DirectionTag direction)
        {
            if (typeof(Mario).IsInstanceOfType(player) && typeof(IFlagpole).IsInstanceOfType(flagpole))
            {
                //do something
                SoundEffectManager.Instance.PlaySoundEffect(SoundEffectManager.SoundEffectTag.StageClear);
                ((Mario)player).Physics.yPosition = flagpole.GetRightSide() + 1;
                Console.WriteLine("asking for player flagpole collision resolution");
            }
        }
    }
}
