using System.Drawing;

namespace KelikGame
{
    public interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}