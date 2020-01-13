using Project.Collision;
using Project.GameObjects;
using System;
using Project.Sound;
using Project.Commands;

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
                //Asking for TransitionForwardCommand;
                GameManager.Instance.HitFlag((GameObjects.GameObject)player, (Flagpole)flagpole);
            }
        }
    }
}
