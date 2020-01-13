using Microsoft.Xna.Framework;

namespace Project.Collision
{
    public interface ICollidable
    {
        int GetTopSide();
        int GetBottomSide();
        int GetLeftSide();
        int GetRightSide();
        int GetWidth();
        int GetHeight();
        Rectangle GetHitBox();
    }
}
