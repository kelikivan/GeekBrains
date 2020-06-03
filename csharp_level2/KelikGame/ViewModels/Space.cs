using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelikGame
{
    public class Space : BaseObject
    {
        static Image Image => Image.FromFile("Images\\background_800x600.png");
        static Image SecondImage => Image.FromFile("Images\\background_800x600.png");

        public Space(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            SecondImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, new PointF(Pos.X, Pos.Y));
            Game.Buffer.Graphics.DrawImage(SecondImage, new PointF(Pos.X - Size.Width, Pos.Y));
        }

        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X >= Game.Width) Pos.X = 0;
        }
    }
}