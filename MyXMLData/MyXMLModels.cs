using System;
using System.Collections.Generic;
using System.Text;

namespace XMLData
{
    public class Frame
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
    }
    public class AnimationCycle
    {
        public String SpriteTag;
        public String SpritesheetName;
        public float FramesPerSecond;
        public List<Frame> Animation;
    }
    public class AnimationList
    {
        public List<AnimationCycle> Animations;
    }
    public class GameObject
    {
        public string ItemName;
        public int X;
        public int Y;
    }

    public class ObjectList
    {
        public List<GameObject> List;
    }
    public class LevelList
    {
        public List<string> Levels;
    }
}
