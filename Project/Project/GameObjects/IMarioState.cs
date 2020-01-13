using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.GameObjects
{
    
    public interface IMarioState
    {
        void BeRunningLeft();
        void BeRunningRight();
        void BeLookingLeft();
        void BeLookingRight();
        void BeJumpingLeft();
        void BeJumpingRight();
        void BeCrouchingLeft();
        void BeCrouchingRight();
        void BeSmall();
        void BeBig();
        void BeFire();
        void BeDead();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
