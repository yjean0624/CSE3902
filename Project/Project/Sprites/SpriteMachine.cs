using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project.Sprites
{ 
    public sealed class SpriteMachine
    {
        public enum SpriteTag
        {
            FireMarioIdleLeft,
            FireMarioIdleRight,
            FireMarioMovingLeft,
            FireMarioMovingRight,
            FireMarioActiveJumpingLeft,
            FireMarioActiveJumpingRight,
            FireMarioPassiveJumpingLeft,
            FireMarioPassiveJumpingRight,
            FireMarioCrouchingLeft,
            FireMarioCrouchingRight,
            FireMarioFallingLeft,
            FireMarioFallingRight,
            FireMarioLeftToRightTransition,
            FireMarioRightToLeftTransition,
            BigMarioIdleLeft,
            BigMarioIdleRight,
            BigMarioMovingLeft,
            BigMarioMovingRight,
            BigMarioActiveJumpingLeft,
            BigMarioActiveJumpingRight,
            BigMarioPassiveJumpingLeft,
            BigMarioPassiveJumpingRight,
            BigMarioCrouchingLeft,
            BigMarioCrouchingRight,
            BigMarioFallingLeft,
            BigMarioFallingRight,
            BigMarioLeftToRightTransition,
            BigMarioRightToLeftTransition,
            SmallMarioIdleLeft,
            SmallMarioIdleRight,
            SmallMarioMovingLeft,
            SmallMarioMovingRight,
            SmallMarioActiveJumpingLeft,
            SmallMarioActiveJumpingRight,
            SmallMarioPassiveJumpingLeft,
            SmallMarioPassiveJumpingRight,
            SmallMarioFallingLeft,
            SmallMarioFallingRight,
            SmallMarioLeftToRightTransition,
            SmallMarioRightToLeftTransition,
            DeadMario,
            SolidBrickBlock,
            GroundBlock1x1, GroundBlock4x65, GroundBlock4x15, GroundBlock4x60, GroundBlock4x54,
            UndergroundBlock1x1, UndergroundBlock4x15,
            UndergroundBrickBlock,
            InvisibleBlock,
            SolidBlock,
            StairBlock,
            QuestionBlock,
            SmallPipe, MediumPipe, LargePipe, LeftFacingPipe,
            Flag,
            FlagPole,
            Goomba, DeadGoomba, GoombaReversed,
            KoopaLeft, KoopaRight, KoopaShell, KoopaShellReversed,
            SpeedBoostItem,
            BrownMushroom,
            Star,
            Flower,
            Coin,
            OneHumpBush, TwoHumpBush, ThreeHumpBush,
            OneHumpCloud, TwoHumpCloud, ThreeHumpCloud,
            TallHill, ShortHill,
            Fireball, FireballExplode
        }

        private Dictionary<String, (Texture2D texture, List<Frame> animation, float FramesPerSecond)> spriteDictionary
                    = new Dictionary<String, (Texture2D texture, List<Frame>, float)>();
        private Dictionary<string, SpriteTag> stringTagDictionary;
        private XMLData.AnimationList animationList;

        //This will become a parameter for LoadAllTextures eventually
        private String fileName = string.Format(Config.GetTexturesFileName());
        public static SpriteMachine Instance { get; } = new SpriteMachine();

        private SpriteMachine()
        {
            //Mario
            spriteDictionary.Add(SpriteTag.FireMarioIdleLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireMarioIdleRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireMarioMovingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireMarioMovingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireMarioActiveJumpingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireMarioActiveJumpingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireMarioPassiveJumpingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireMarioPassiveJumpingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireMarioCrouchingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireMarioCrouchingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireMarioFallingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireMarioFallingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireMarioLeftToRightTransition.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireMarioRightToLeftTransition.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioIdleLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioIdleRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioMovingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioMovingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioActiveJumpingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioActiveJumpingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioPassiveJumpingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioPassiveJumpingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioCrouchingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioCrouchingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioFallingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioFallingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioLeftToRightTransition.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.BigMarioRightToLeftTransition.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SmallMarioIdleLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SmallMarioIdleRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SmallMarioMovingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SmallMarioMovingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SmallMarioActiveJumpingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SmallMarioActiveJumpingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SmallMarioPassiveJumpingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SmallMarioPassiveJumpingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SmallMarioFallingLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SmallMarioFallingRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SmallMarioLeftToRightTransition.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SmallMarioRightToLeftTransition.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.DeadMario.ToString(), (null, null, 0.0f));

            //World
            spriteDictionary.Add(SpriteTag.SolidBrickBlock.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.GroundBlock1x1.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.GroundBlock4x65.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.GroundBlock4x15.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.GroundBlock4x60.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.GroundBlock4x54.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.UndergroundBrickBlock.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.UndergroundBlock4x15.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.UndergroundBlock1x1.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.InvisibleBlock.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.StairBlock.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.QuestionBlock.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SolidBlock.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.Flag.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FlagPole.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SmallPipe.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.MediumPipe.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.LargePipe.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.LeftFacingPipe.ToString(), (null, null, 0.0f));


            //Enemies
            spriteDictionary.Add(SpriteTag.Goomba.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.DeadGoomba.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.GoombaReversed.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.KoopaRight.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.KoopaLeft.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.KoopaShell.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.KoopaShellReversed.ToString(), (null, null, 0.0f));

            //Items
            spriteDictionary.Add(SpriteTag.BrownMushroom.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.SpeedBoostItem.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.Coin.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.Flower.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.Star.ToString(), (null, null, 0.0f));

            //Background
            spriteDictionary.Add(SpriteTag.OneHumpBush.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.TwoHumpBush.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.ThreeHumpBush.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.ShortHill.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.TallHill.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.OneHumpCloud.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.TwoHumpCloud.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.ThreeHumpCloud.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.Fireball.ToString(), (null, null, 0.0f));
            spriteDictionary.Add(SpriteTag.FireballExplode.ToString(), (null, null, 0.0f));

            stringTagDictionary = new Dictionary<String, SpriteTag>();
            stringTagDictionary.Add("BigMarioState" + "LeftFacingMarioState", SpriteTag.BigMarioIdleLeft);
            stringTagDictionary.Add("SmallMarioState" + "LeftFacingMarioState", SpriteTag.SmallMarioIdleLeft);
            stringTagDictionary.Add("FireMarioState" + "LeftFacingMarioState", SpriteTag.FireMarioIdleLeft);
            stringTagDictionary.Add("DeadMarioState" + "LeftFacingMarioState", SpriteTag.DeadMario);
            stringTagDictionary.Add("BigMarioState" + "RightFacingMarioState", SpriteTag.BigMarioIdleRight);
            stringTagDictionary.Add("SmallMarioState" + "RightFacingMarioState", SpriteTag.SmallMarioIdleRight);
            stringTagDictionary.Add("FireMarioState" + "RightFacingMarioState", SpriteTag.FireMarioIdleRight);
            stringTagDictionary.Add("DeadMarioState" + "RightFacingMarioState", SpriteTag.DeadMario);
            stringTagDictionary.Add("BigMarioState" + "LeftMovingMarioState", SpriteTag.BigMarioMovingLeft);
            stringTagDictionary.Add("SmallMarioState" + "LeftMovingMarioState", SpriteTag.SmallMarioMovingLeft);
            stringTagDictionary.Add("FireMarioState" + "LeftMovingMarioState", SpriteTag.FireMarioMovingLeft);
            stringTagDictionary.Add("DeadMarioState" + "LeftMovingMarioState", SpriteTag.DeadMario);
            stringTagDictionary.Add("BigMarioState" + "RightMovingMarioState", SpriteTag.BigMarioMovingRight);
            stringTagDictionary.Add("SmallMarioState" + "RightMovingMarioState", SpriteTag.SmallMarioMovingRight);
            stringTagDictionary.Add("FireMarioState" + "RightMovingMarioState", SpriteTag.FireMarioMovingRight);
            stringTagDictionary.Add("DeadMarioState" + "RightMovingMarioState", SpriteTag.DeadMario);
            stringTagDictionary.Add("BigMarioState" + "LeftActiveJumpingMarioState", SpriteTag.BigMarioActiveJumpingLeft);
            stringTagDictionary.Add("SmallMarioState" + "LeftActiveJumpingMarioState", SpriteTag.SmallMarioActiveJumpingLeft);
            stringTagDictionary.Add("DeadMarioState" + "LeftActiveJumpingMarioState", SpriteTag.DeadMario);
            stringTagDictionary.Add("FireMarioState" + "LeftActiveJumpingMarioState", SpriteTag.FireMarioActiveJumpingLeft);
            stringTagDictionary.Add("BigMarioState" + "LeftPassiveJumpingMarioState", SpriteTag.BigMarioPassiveJumpingLeft);
            stringTagDictionary.Add("SmallMarioState" + "LeftPassiveJumpingMarioState", SpriteTag.SmallMarioPassiveJumpingLeft);
            stringTagDictionary.Add("FireMarioState" + "LeftPassiveJumpingMarioState", SpriteTag.FireMarioPassiveJumpingLeft);
            stringTagDictionary.Add("DeadMarioState" + "LeftPassiveJumpingMarioState", SpriteTag.DeadMario);
            stringTagDictionary.Add("BigMarioState" + "RightActiveJumpingMarioState", SpriteTag.BigMarioActiveJumpingRight);
            stringTagDictionary.Add("SmallMarioState" + "RightActiveJumpingMarioState", SpriteTag.SmallMarioActiveJumpingRight);
            stringTagDictionary.Add("FireMarioState" + "RightActiveJumpingMarioState", SpriteTag.FireMarioActiveJumpingRight);
            stringTagDictionary.Add("DeadMarioState" + "RightActiveJumpingMarioState", SpriteTag.DeadMario);
            stringTagDictionary.Add("BigMarioState" + "RightPassiveJumpingMarioState", SpriteTag.BigMarioPassiveJumpingRight);
            stringTagDictionary.Add("SmallMarioState" + "RightPassiveJumpingMarioState", SpriteTag.SmallMarioPassiveJumpingRight);
            stringTagDictionary.Add("FireMarioState" + "RightPassiveJumpingMarioState", SpriteTag.FireMarioPassiveJumpingRight);
            stringTagDictionary.Add("DeadMarioState" + "RightPassiveJumpingMarioState", SpriteTag.DeadMario);
            stringTagDictionary.Add("BigMarioState" + "LeftCrouchingMarioState", SpriteTag.BigMarioCrouchingLeft);
            stringTagDictionary.Add("SmallMarioState" + "LeftCrouchingMarioState", SpriteTag.SmallMarioIdleLeft);
            stringTagDictionary.Add("FireMarioState" + "LeftCrouchingMarioState", SpriteTag.FireMarioCrouchingLeft);
            stringTagDictionary.Add("DeadMarioState" + "LeftCrouchingMarioState", SpriteTag.DeadMario);
            stringTagDictionary.Add("BigMarioState" + "RightCrouchingMarioState", SpriteTag.BigMarioCrouchingRight);
            stringTagDictionary.Add("SmallMarioState" + "RightCrouchingMarioState", SpriteTag.SmallMarioIdleRight);
            stringTagDictionary.Add("FireMarioState" + "RightCrouchingMarioState", SpriteTag.FireMarioCrouchingRight);
            stringTagDictionary.Add("DeadMarioState" + "RightCrouchingMarioState", SpriteTag.DeadMario);
            stringTagDictionary.Add("BigMarioState" + "LeftFallingMarioState", SpriteTag.BigMarioFallingLeft);
            stringTagDictionary.Add("SmallMarioState" + "LeftFallingMarioState", SpriteTag.SmallMarioFallingLeft);
            stringTagDictionary.Add("FireMarioState" + "LeftFallingMarioState", SpriteTag.FireMarioFallingLeft);
            stringTagDictionary.Add("DeadMarioState" + "LeftFallingMarioState", SpriteTag.DeadMario);
            stringTagDictionary.Add("BigMarioState" + "RightFallingMarioState", SpriteTag.BigMarioFallingRight);
            stringTagDictionary.Add("SmallMarioState" + "RightFallingMarioState", SpriteTag.SmallMarioFallingRight);
            stringTagDictionary.Add("FireMarioState" + "RightFallingMarioState", SpriteTag.FireMarioFallingRight);
            stringTagDictionary.Add("DeadMarioState" + "RightFallingMarioState", SpriteTag.DeadMario);
            stringTagDictionary.Add("BigMarioState" + "LeftToRightTransitionMarioState", SpriteTag.BigMarioLeftToRightTransition);
            stringTagDictionary.Add("SmallMarioState" + "LeftToRightTransitionMarioState", SpriteTag.SmallMarioLeftToRightTransition);
            stringTagDictionary.Add("FireMarioState" + "LeftToRightTransitionMarioState", SpriteTag.FireMarioLeftToRightTransition);
            stringTagDictionary.Add("DeadMarioState" + "LeftToRightTransitionMarioState", SpriteTag.DeadMario);
            stringTagDictionary.Add("BigMarioState" + "RightToLeftTransitionMarioState", SpriteTag.BigMarioRightToLeftTransition);
            stringTagDictionary.Add("SmallMarioState" + "RightToLeftTransitionMarioState", SpriteTag.SmallMarioRightToLeftTransition);
            stringTagDictionary.Add("FireMarioState" + "RightToLeftTransitionMarioState", SpriteTag.FireMarioRightToLeftTransition);
            stringTagDictionary.Add("DeadMarioState" + "RightToLeftTransitionMarioState", SpriteTag.DeadMario);
        }

        public void LoadAllTextures(ContentManager content)
        {
            animationList = content.Load<XMLData.AnimationList>(fileName);
            foreach(XMLData.AnimationCycle cycle in animationList.Animations)
            {
                if(spriteDictionary.ContainsKey(cycle.SpriteTag))
                {
                    addAnimation(content, cycle);
                }
                else
                {
                    Console.WriteLine(string.Format(Config.GetTextureLoadingExceptionString(),cycle.SpriteTag));
                }
            }
            verifyTextures();
        }
        /// <summary>
        /// Verifies that each entry in the Sprite dictionary has a frame and
        /// prints out information on which ones are missing
        /// </summary>
        private void verifyTextures()
        {
            Console.WriteLine("Verifying Textures");
            foreach (String tag in spriteDictionary.Keys)
            {
                if(spriteDictionary[tag].animation == null)
                {
                    Console.WriteLine(string.Format(Config.GetVerifyingTexturesFrameDataExceptionString(),tag));
                }
                if(spriteDictionary[tag].texture == null)
                {
                    Console.WriteLine(string.Format(Config.GetVerifyingTexturesSpritesheetDataExceptionString(), tag));
                }
                if (spriteDictionary[tag].FramesPerSecond == 0.0f)
                {
                    Console.WriteLine(string.Format(Config.GetVerifyingTexturesFramerateExceptionString(), tag));
                }
            }
        }
        private void addAnimation(ContentManager content, XMLData.AnimationCycle cycle)
        {
            Texture2D spritesheet = content.Load<Texture2D>(cycle.SpritesheetName);
            spriteDictionary[cycle.SpriteTag] = (spritesheet, new List<Frame>(), cycle.FramesPerSecond);
            foreach (XMLData.Frame xmlFrame in cycle.Animation)
            {
                Sprites.Frame nextFrame = new Sprites.Frame(xmlFrame.X, xmlFrame.Y,
                                                          xmlFrame.Width, xmlFrame.Height);
                spriteDictionary[cycle.SpriteTag].animation.Add(nextFrame);
            }
        }

        public ISprite CreateSprite(String identifyingString)
        {
            SpriteTag tag = stringTagDictionary[identifyingString];
            return new Sprite(spriteDictionary[tag.ToString()].texture,
                              spriteDictionary[tag.ToString()].animation,
                              spriteDictionary[tag.ToString()].FramesPerSecond);
        }

        public ISprite CreateSprite(SpriteTag tag)
        {
            return new Sprite(spriteDictionary[tag.ToString()].texture,
                              spriteDictionary[tag.ToString()].animation,
                              spriteDictionary[tag.ToString()].FramesPerSecond);
        }
    }
}