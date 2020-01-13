namespace Project.Sprites
{
    /*
     * This class is simply a data structure for the values 
     * that define a frame of animation in a spritesheet.
     * x is the number of pixels between the left side of the 
     * spritesheet and the left side of the animation frame.
     * y is the number of pixels between the top side of the 
     * spritesheet and the top side of the animation frame.
     * width is the number of pixels between the left side of the 
     * animation frame and the right side of the animation frame.
     * height is the number of pixels between the top side of the 
     * animation frame and the bottom side of the animation frame.
     */
    class Frame
    {
        private int x;
        private int y;
        private int width;
        private int height;
        public Frame(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public int GetX()
        {
            return this.x;
        }
        public int GetY()
        {
            return this.y;
        }
        public int GetWidth()
        {
            return this.width;
        }
        public int GetHeight()
        {
            return this.height;
        }
    }
}
