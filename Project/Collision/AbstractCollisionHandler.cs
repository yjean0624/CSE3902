using System;
using System.Collections.Generic;
using System.Reflection;
using Project.GameObjects;

namespace Project.Collision
{
    public abstract class AbstractCollisionHandler : ICollisionHandler
    {
        protected Dictionary<(Type, Type), Type> collisionResolutionMap = new Dictionary<(Type, Type), Type>();
        public AbstractCollisionHandler()
        {
        }
        public void Handle(ICollidable object1, ICollidable object2, CollisionDirection.DirectionTag direction)
        {
            foreach (KeyValuePair<(Type, Type), Type> entry in collisionResolutionMap)
            {
                if (entry.Key.Item1.IsInstanceOfType(object1) && entry.Key.Item2.IsInstanceOfType(object2))
                {
                    ConstructorInfo constructor = entry.Value.GetConstructors()[0];
                    ICollisionHandler resolution = constructor.Invoke(new object[] {}) as ICollisionHandler;
                    resolution.Handle(object1, object2, direction);
                }
            }
        }
    }
}
