using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelikGame
{
    public class Asteroid : BaseObject, IRegenerator, ICloneable, IComparable<Asteroid>
    {
        static Image Image => Image.FromFile("Images\\asteroid_60x60.png");

        public int Power { get; set; } = 3;

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, new RectangleF(Pos.X, Pos.Y, Size.Width, Size.Height));
        }

        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0) Reset();
        }

        public void Reset()
        {
            Pos.X = Game.Width + Size.Width / 2;
        }

        public object Clone()
        {
            Asteroid asteroid = new Asteroid(
                new Point(Pos.X, Pos.Y), 
                new Point(Dir.X, Dir.Y),
                new Size(Size.Width, Size.Height))
            { 
                Power = Power
            };
            return asteroid;
        }
        int IComparable<Asteroid>.CompareTo(Asteroid obj)
        {
            if (Power > obj.Power)
                return 1;
            if (Power < obj.Power)
                return -1;
            return 0;
        }
    }
}