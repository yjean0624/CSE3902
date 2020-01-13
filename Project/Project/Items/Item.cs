using Project.Levels;
using Project.GameObjects;
using Microsoft.Xna.Framework;
using Project.Sound;

namespace Project.Items
{
    public abstract class Item : GameObject, IItem
    {
        protected Item(Vector2 location):base(location)
        {
        }
        public virtual void Collect()
        {
            GameManager.Instance.Remove(this);
        }
    }
}
