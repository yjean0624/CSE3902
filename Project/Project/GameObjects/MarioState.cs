using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.GameObjects
{
    public class MarioState : IMarioState
    {
        enum MovementState {RunningLeft, RunningRight, LookingLeft, LookingRight,
                    JumpingLeft, JumpingRight, CrouchingLeft, CrouchingRight};
        enum StatusState { Small, Big, Fire, Dead};
        private Player myGameObject;
        private MovementState currentMovementState;
        private StatusState currentStatusState;
        private Sprites.IMarioSprite mySprite;
        public MarioState(Player myGameObject, Sprites.IMarioSprite mySprite)
        {
            this.myGameObject = myGameObject;
            this.currentMovementState = MovementState.LookingRight;
            this.currentStatusState = StatusState.Small;
            this.mySprite = mySprite;
        }

        public void BeCrouchingLeft()
        {
            if (currentStatusState != StatusState.Dead)
            {
                if (currentMovementState == MovementState.RunningLeft || currentMovementState == MovementState.LookingLeft)
                {
                    currentMovementState = MovementState.CrouchingLeft;
                }
                else if (currentMovementState == MovementState.JumpingLeft)
                {
                    currentMovementState = MovementState.LookingLeft;
                }
                else if (currentMovementState == MovementState.LookingRight)
                {
                    currentMovementState = MovementState.LookingLeft;
                }
                else if (currentMovementState == MovementState.RunningRight || currentMovementState == MovementState.JumpingRight
                      || currentMovementState == MovementState.CrouchingRight)
                {
                    currentMovementState = MovementState.LookingRight;
                }
            }
        }

        public void BeCrouchingRight()
        {
            if (currentStatusState != StatusState.Dead)
            {
                if (currentMovementState == MovementState.RunningRight || currentMovementState == MovementState.LookingRight)
                {
                    currentMovementState = MovementState.CrouchingRight;
                }
                else if (currentMovementState == MovementState.JumpingRight)
                {
                    currentMovementState = MovementState.LookingRight;
                }
                else if (currentMovementState == MovementState.LookingLeft)
                {
                    currentMovementState = MovementState.LookingRight;
                }
                else if (currentMovementState == MovementState.RunningLeft || currentMovementState == MovementState.JumpingLeft
                      || currentMovementState == MovementState.CrouchingLeft)
                {
                    currentMovementState = MovementState.LookingLeft;
                }
            }
        }

        public void BeJumpingLeft()
        {
            if (currentStatusState != StatusState.Dead)
            {
                if (currentMovementState == MovementState.RunningLeft || currentMovementState == MovementState.LookingLeft)
                {
                    currentMovementState = MovementState.JumpingLeft;
                }
                else if (currentMovementState == MovementState.CrouchingLeft || currentMovementState == MovementState.LookingRight)
                {
                    currentMovementState = MovementState.LookingLeft;
                }
                else if (currentMovementState == MovementState.CrouchingRight || currentMovementState == MovementState.RunningRight
                      || currentMovementState == MovementState.JumpingRight)
                {
                    currentMovementState = MovementState.LookingRight;
                }
            }
        }

        public void BeJumpingRight()
        {
            if (currentStatusState != StatusState.Dead)
            {
                if (currentMovementState == MovementState.RunningRight || currentMovementState == MovementState.LookingRight)
                {
                    currentMovementState = MovementState.JumpingRight;
                }
                else if (currentMovementState == MovementState.CrouchingRight || currentMovementState == MovementState.LookingLeft)
                {
                    currentMovementState = MovementState.LookingRight;
                }
                else if (currentMovementState == MovementState.CrouchingLeft || currentMovementState == MovementState.RunningLeft
                      || currentMovementState == MovementState.JumpingLeft)
                {
                    currentMovementState = MovementState.LookingLeft;
                }
            }
        }

        public void BeLookingLeft()
        {
            if (currentStatusState != StatusState.Dead)
            {
                if (currentMovementState == MovementState.RunningLeft || currentMovementState == MovementState.CrouchingLeft
                 || currentMovementState == MovementState.JumpingLeft || currentMovementState == MovementState.LookingRight)
                {
                    currentMovementState = MovementState.LookingLeft;
                }
            }
        }

        public void BeLookingRight()
        {
            if (currentStatusState != StatusState.Dead)
            {
                if (currentMovementState == MovementState.RunningRight || currentMovementState == MovementState.CrouchingRight
                 || currentMovementState == MovementState.JumpingRight || currentMovementState == MovementState.LookingLeft)
                {
                    currentMovementState = MovementState.LookingRight;
                }
            }
        }

        public void BeRunningLeft()
        {
            if (currentStatusState != StatusState.Dead)
            {
                if (currentMovementState == MovementState.CrouchingLeft || currentMovementState == MovementState.JumpingLeft
                || currentMovementState == MovementState.LookingLeft)
                {
                    currentMovementState = MovementState.RunningLeft;
                }
                else if (currentMovementState == MovementState.LookingRight)
                {
                    currentMovementState = MovementState.LookingLeft;
                }
                else if (currentMovementState == MovementState.JumpingRight || currentMovementState == MovementState.RunningRight
                      || currentMovementState == MovementState.CrouchingRight)
                {
                    currentMovementState = MovementState.LookingRight;
                }
            }
        }

        public void BeRunningRight()
        {
            if (currentStatusState != StatusState.Dead)
            {
                if (currentMovementState == MovementState.CrouchingRight || currentMovementState == MovementState.JumpingRight
                || currentMovementState == MovementState.LookingRight)
                {
                    currentMovementState = MovementState.RunningRight;
                }
                else if (currentMovementState == MovementState.LookingLeft)
                {
                    currentMovementState = MovementState.LookingRight;
                }
                else if (currentMovementState == MovementState.JumpingLeft || currentMovementState == MovementState.RunningLeft
                      || currentMovementState == MovementState.CrouchingLeft)
                {
                    currentMovementState = MovementState.LookingLeft;
                }
            }
        }

        public void BeJumping()
        {
            if (currentStatusState != StatusState.Dead)
            {
                if (currentMovementState == MovementState.CrouchingLeft)
                {
                    currentMovementState = MovementState.LookingLeft;
                }
                else if (currentMovementState == MovementState.RunningLeft || currentMovementState == MovementState.LookingLeft)
                {
                    currentMovementState = MovementState.JumpingLeft;
                }
                else if (currentMovementState == MovementState.CrouchingRight)
                {
                    currentMovementState = MovementState.LookingRight;
                }
                else if (currentMovementState == MovementState.LookingRight || currentMovementState == MovementState.RunningRight)
                {
                    currentMovementState = MovementState.JumpingRight;
                }
            }
        }

        public void BeCrouching()
        {
            if (currentStatusState != StatusState.Dead)
            {
                if (currentMovementState == MovementState.JumpingLeft)
                {
                    currentMovementState = MovementState.LookingLeft;
                }
                else if (currentMovementState == MovementState.RunningLeft || currentMovementState == MovementState.LookingLeft)
                {
                    currentMovementState = MovementState.CrouchingLeft;
                }
                else if (currentMovementState == MovementState.JumpingRight)
                {
                    currentMovementState = MovementState.LookingRight;
                }
                else if (currentMovementState == MovementState.LookingRight || currentMovementState == MovementState.RunningRight)
                {
                    currentMovementState = MovementState.CrouchingRight;
                }
            }
        }
        public void BeSmall()
        {
            if (currentStatusState != StatusState.Small)
            { 
                currentStatusState = StatusState.Small;
                mySprite = Sprites.SpriteMachine.Instance.CreateSmallMarioSprite();
            }
        }
        public void BeBig()
        {
            if (currentStatusState != StatusState.Big)
            {
                currentStatusState = StatusState.Big;
                mySprite = Sprites.SpriteMachine.Instance.CreateBigMarioSprite();
            }
        }
        public void BeFire()
        {
            if (currentStatusState != StatusState.Fire)
            {
                currentStatusState = StatusState.Fire;
                mySprite = Sprites.SpriteMachine.Instance.CreateFireMarioSprite();
            }
        }
        public void BeDead()
        {
            if (currentStatusState != StatusState.Dead)
            {
                currentStatusState = StatusState.Dead;
            }
        }
        public void Update()
        {
            if (currentStatusState != StatusState.Dead)
            {
                if (currentMovementState == MovementState.LookingLeft)
                {
                    mySprite.SetToStanding(false);
                }
                else if (currentMovementState == MovementState.LookingRight)
                {
                    mySprite.SetToStanding(true);
                }
                else if (currentMovementState == MovementState.RunningLeft)
                {
                    mySprite.SetToRunning(false);
                }
                else if (currentMovementState == MovementState.RunningRight)
                {
                    mySprite.SetToRunning(true);
                }
                else if (currentMovementState == MovementState.CrouchingLeft)
                {
                    mySprite.SetToCrouching(false);
                }
                else if (currentMovementState == MovementState.CrouchingRight)
                {
                    mySprite.SetToCrouching(true);
                }
                else if (currentMovementState == MovementState.JumpingLeft)
                {
                    mySprite.SetToJumping(false);
                }
                else if (currentMovementState == MovementState.JumpingRight)
                {
                    mySprite.SetToJumping(true);
                }
                mySprite.Update();
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            mySprite.Draw(spriteBatch, location);
        }
    }
}
