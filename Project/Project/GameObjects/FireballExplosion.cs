using Project.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;

namespace Project.GameObjects
{
    public class FireballExplosion : IGameObject
    {
        private Vector2 centralLocation;
        private ISprite topLeftSprite;
        private ISprite topRightSprite;
        private ISprite bottomRightSprite;
        private ISprite bottomLeftSprite;
        private readonly float maximumExpansion = Config.GetMaximumExpansionOfFireballExplosion();
        private float expansion = 10f;
        public FireballExplosion(Vector2 location)
        {
            centralLocation = location;
            topLeftSprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.FireballExplode);
            topRightSprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.FireballExplode);
            bottomRightSprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.FireballExplode);
            bottomLeftSprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.FireballExplode);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            topLeftSprite.Draw(spriteBatch,new Vector2(centralLocation.X - expansion,centralLocation.Y - expansion));
            topRightSprite.Draw(spriteBatch, new Vector2(centralLocation.X + expansion, centralLocation.Y - expansion));
            bottomRightSprite.Draw(spriteBatch, new Vector2(centralLocation.X + expansion, centralLocation.Y + expansion));
            bottomLeftSprite.Draw(spriteBatch, new Vector2(centralLocation.X - expansion, centralLocation.Y + expansion));
        }

        public Vector2 Location()
        {
            return centralLocation;
        }

        public void Update(GameTime gameTime)
        {
            expansion += 1;
            if(expansion>maximumExpansion)
            {
                GameManager.Instance.Remove(this);
            }
        }
    }
}
