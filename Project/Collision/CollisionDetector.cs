using System.Collections.Generic;
using System.Linq;
using Project.Levels;
using Project.GameObjects;
using Microsoft.Xna.Framework;

namespace Project.Collision
{
    public class CollisionDetector
    {
        public static CollisionDetector Instance { get; } = new CollisionDetector();
        private CollisionDetector()
        {
            //Get Static List from Game manager
        }
        /*
         *  Object1 is on the {DirectionTag} of object2
         */
        private CollisionDirection.DirectionTag GetCollisionDirection(GameObject object1, GameObject object2)
        {
            CollisionDirection.DirectionTag direction;
            Rectangle gameObject1HitBox = object1.GetHitBox();
            Rectangle gameObject2HitBox = object2.GetHitBox();
            Rectangle overlap = Rectangle.Intersect(gameObject1HitBox, gameObject2HitBox);
            int dx = overlap.Width;
            int dy = overlap.Height;
            if (CheckCollision(gameObject1HitBox, gameObject2HitBox))
            {
                if (dy <= dx)
                {
                    if (object1.GetTopSide() < object2.GetTopSide())
                    {
                        direction = CollisionDirection.DirectionTag.Top;
                    }
                    else
                    {
                        direction = CollisionDirection.DirectionTag.Bottom;
                    }
                }
                else
                {
                    if (object1.GetLeftSide() < object2.GetLeftSide())
                    {
                        direction = CollisionDirection.DirectionTag.Left;
                    }
                    else
                    {
                        direction = CollisionDirection.DirectionTag.Right;
                    }
                }
            }
            else
            {
                direction = CollisionDirection.DirectionTag.NoCollision;
            }
            return direction;
        }
        private bool CheckCollision(Rectangle hitBox1, Rectangle hitBox2)
        {
            return hitBox1.Intersects(hitBox2);
        }
        private void CallCollisionResponse(GameObject object1, GameObject object2)
        {
            CollisionDirection.DirectionTag direction;
            direction = GetCollisionDirection(object1, object2);
            if (direction != CollisionDirection.DirectionTag.NoCollision)
            {
                GeneralCollisionHandler collisionHandler = new GeneralCollisionHandler();
                collisionHandler.Handle(object1, object2, direction);
            }
        }

        /*
         * DetectCollision will loop through lists once for collisions 
         */
        public void DetectCollision()
        {
            List<GameObjects.GameObject> dynamicCollidables = GameManager.Instance.GetCollidableMovers();
            List<GameObjects.GameObject> staticCollidables = GameManager.Instance.GetCollidableNonMovers();
            GameObjects.GameObject object1;
            GameObjects.GameObject object2;
            for (int i = dynamicCollidables.Count - 1; i >= 0; i--)
            {
                object1 = dynamicCollidables.ElementAt(i);
                for (int j = i - 1; j >= 0; j--)
                {
                    object2 = dynamicCollidables.ElementAt(j);
                    CallCollisionResponse(object1, object2);
                }
                for (int j = staticCollidables.Count - 1; j >= 0; j--)
                {
                    object2 = staticCollidables.ElementAt(j);
                    CallCollisionResponse(object1, object2);
                }
            }
        }
    }
}
