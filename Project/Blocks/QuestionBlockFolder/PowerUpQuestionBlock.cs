﻿using Microsoft.Xna.Framework;
using Project.Sprites;

namespace Project.Blocks
{
    public class PowerUpQuestionBlock : AbstractQuestionBlock
    {
        public PowerUpQuestionBlock(Vector2 location) : base(location)
        {
            //TODO: sprite is now managed by game object, not sure if it should be managed by gameObject or state.
            sprite = SpriteMachine.Instance.CreateSprite(SpriteMachine.SpriteTag.QuestionBlock);
            itemState = new BrownMushroomState(this);
        }
        public override void Bump()
        {
            base.Bump();
            itemState.ReleaseItem();
        }
    }
}
