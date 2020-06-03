using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelikGame
{
    public class Asteroid : BaseObject
    {
        static Image Image => Image.FromFile("Images\\asteroid_60x60.png");

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, new PointF(Pos.X, Pos.Y));
        }

        public override void Update()
        {
            Pos.X += Dir.X;
            //Pos.Y += Dir.Y;
            if (Pos.X < 0 || Pos.X > Game.Width) Dir.X = -Dir.X;
            //if (Pos.Y < 0 || Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}