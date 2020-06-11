using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelikGame
{
    public abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            if (pos.Y < 0 || pos.Y > Game.Height)
                throw new GameObjectException("Некорректные параметры позиции объекта. Объект не создан!");

            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();

        public abstract void Update();

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}