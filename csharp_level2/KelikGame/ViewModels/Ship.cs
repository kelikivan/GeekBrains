using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelikGame
{
    public class Ship : BaseObject
    {
        private int _energy = 100;
        public int Energy => _energy;

        public static event Message MessageDie;
        private static Image Image => Image.FromFile("Images\\ship.png");

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
        }

        public void Up()
        {
            if (Pos.Y > 0) Pos.Y -= Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y += Dir.Y;
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }

        public void EnergyLow(int n)
        {
            _energy -= n;
        }
    }
}
