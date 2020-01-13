using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project.Sprites
{
    /*
     * This class handles all of the graphics for an item.
     */
    public class FireMarioSprite : IMarioSprite
    {
        private Texture2D Texture;
        private int animationPosition;//the position in the current animation cycle
        private int[,] standingRightMap;
        private int[,] runningRightMap;
        private int[,] jumpingRightMap;
        private int[,] standingLeftMap;
        private int[,] runningLeftMap;
        private int[,] jumpingLeftMap;
        private int[,] crouchingLeftMap;
        private int[,] crouchingRightMap;
        private int[,] currentMap;
        private const int CALLS_PER_UPDATE = 5;//how many times update is called to animate
        private int updateCounter = 0;
        public FireMarioSprite(Texture2D texture)
        {
            Texture = texture;
            standingRightMap = Config.GetStandingRightMapForFireMarioSprite();
            runningRightMap = Config.GetRunningRightMapForFireMarioSprite();
            jumpingRightMap = Config.GetJumpingRightMapForFireMarioSprite();
            standingLeftMap = Config.GetStandingLeftMapForFireMarioSprite();
            runningLeftMap = Config.GetRunningLeftMapForFireMarioSprite();
            jumpingLeftMap = Config.GetJumpingLeftMapForFireMarioSprite();
            crouchingLeftMap = Config.GetCrouchingLeftMapForFireMarioSprite();
            crouchingRightMap = Config.GetCrouchingRightMapForFireMarioSprite();
            currentMap = standingRightMap;
            animationPosition = 0;
        }

        /*
         * Updates the frame of the sprite that will be shown
         */
        public void Update()
        {
            updateCounter++;
            if (updateCounter >= CALLS_PER_UPDATE)
            {
                updateCounter = 0;
                animationPosition++;
                if (animationPosition >= currentMap.Length / 4)
                {
                    animationPosition = 0;
                }
            }
        }

        /*
         * Draws the frame that is set to be be drawn
         */
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            Rectangle sourceRectangle = new Rectangle(currentMap[animationPosition, 0],
                                                      currentMap[animationPosition, 1],
                                                      currentMap[animationPosition, 2],
                                                      currentMap[animationPosition, 3]);
            spriteBatch.Draw(Texture, location, sourceRectangle, Color.White);
        }
        /*
         * If not already jumping, set the animation sequence to jumping
         */
        public void SetToJumping(bool facingRight)
        {
            if (facingRight && !currentMap.Equals(jumpingRightMap))
            {
                currentMap = jumpingRightMap;
                animationPosition = 0;
            }
            else if (!facingRight && !currentMap.Equals(jumpingLeftMap))
            {
                currentMap = jumpingLeftMap;
                animationPosition = 0;
            }
        }
        /*
         * If not already standing, set the animation sequence to standing
         */
        public void SetToStanding(bool facingRight)
        {
            if (facingRight && !currentMap.Equals(standingRightMap))
            {
                currentMap = standingRightMap;
                animationPosition = 0;
            }
            else if (!facingRight && !currentMap.Equals(standingLeftMap))
            {
                currentMap = standingLeftMap;
                animationPosition = 0;
            }
        }
        /*
         * If not already running, set the animation sequence to running
         */
        public void SetToRunning(bool facingRight)
        {
            if (facingRight && !currentMap.Equals(runningRightMap))
            {
                currentMap = runningRightMap;
                animationPosition = 0;
            }
            else if (!facingRight && !currentMap.Equals(runningLeftMap))
            {
                currentMap = runningLeftMap;
                animationPosition = 0;
            }
        }

        /*
         * If not already crouching, set the animation sequence to crouching
         */
        public void SetToCrouching(bool facingRight)
        {
            if (facingRight && !currentMap.Equals(crouchingRightMap))
            {
                currentMap = crouchingRightMap;
                animationPosition = 0;
            }
            else if (!facingRight && !currentMap.Equals(crouchingLeftMap))
            {
                currentMap = crouchingLeftMap;
                animationPosition = 0;
            }
        }
    }
}
