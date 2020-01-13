using Project.Collision;
using Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.GameObjects
{
    public abstract class GameObject : IGameObject, ICollidable
    {
        public Physics Physics;
        protected ISprite sprite { get; set; }
        protected GameObject(Vector2 location)
        {
            Physics = new Physics(location);
        }

        public virtual Vector2 Location()
        {
            return new Vector2(Physics.xPosition, Physics.yPosition);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location());
        }

        public virtual void Update(GameTime gameTime)
        {
            Physics.Update(gameTime);
            sprite.Update(gameTime);
            if(Physics.yPosition > Config.GetDespawnThreshhold())
            {
                GameManager.Instance.Remove(this);
            }
        }

        public virtual void ChangeDirection()
        {
            Physics.xVelocity *= -1;
        }
        public virtual void Ground()
        {
            Physics.yVelocity = 0;
        }

        public virtual int GetTopSide()
        {
            return (int)Physics.yPosition;
        }

        public virtual int GetBottomSide()
        {
            return (int)(Physics.yPosition + sprite.GetHeight());
        }

        public virtual int GetLeftSide()
        {
            return (int)Physics.xPosition;
        }

        public virtual int GetRightSide()
        {
            return (int)(Physics.xPosition + sprite.GetWidth());
        }

        public virtual Rectangle GetHitBox()
        {
            return new Rectangle(GetLeftSide(), GetTopSide(), GetRightSide() - GetLeftSide() + 1, GetBottomSide() - GetTopSide() + 1);
        }

        public int GetWidth()
        {
            return sprite.GetWidth();
        }

        public int GetHeight()
        {
            return sprite.GetHeight();
        }
    }
}
