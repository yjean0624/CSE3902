using Microsoft.Xna.Framework;
using Project.GameObjects;
using Project.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Enemies
{
    public class StompedGoomba: GameObject
    {
        private TimeSpan timer;
        public StompedGoomba(Vector2 location) : base(location)
        {
            Sound.SoundEffectManager.Instance.PlaySoundEffect(Sound.SoundEffectManager.SoundEffectTag.Stomp);
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.DeadGoomba);
            Physics = new Physics(location);
            timer = TimeSpan.FromMilliseconds(Config.GetStompedGoombaDisappearTime());
            Physics.yAcceleration = 0;
        }

        
        public override void Update(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime;
            if (timer <= TimeSpan.Zero)
            {
                GameManager.Instance.Remove(this);
            }
            Physics.Update(gameTime);
            sprite.Update(gameTime);
        }
    }
}
