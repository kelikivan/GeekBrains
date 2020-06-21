using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelikGame
{
    public class MedicineChest : BaseObject
    {
        static readonly Image Image = Image.FromFile("Images\\medicial_chest.png");
        static readonly Random Rnd = new Random();

        public bool IsActive { get; private set; } = true;
        public int Energy { get; set; }

        public MedicineChest(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Energy = Rnd.Next(1, 5);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, new RectangleF(Pos.X, Pos.Y, Size.Width, Size.Height));
        }

        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0) IsActive = false;
        }
    }
}
