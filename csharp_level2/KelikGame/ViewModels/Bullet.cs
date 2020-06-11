using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelikGame
{
    public class Bullet : BaseObject, IRegenerator
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X > Game.Width)
            {
                Reset();
            }
        }

        public void Reset()
        {
            Pos.X = 0;
            Pos.Y -= Dir.Y;
        }
    }
}