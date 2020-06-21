using KelikGame.Basics;
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
        private static Image Image => Image.FromFile("Images\\ship.png");

        private int _energy = 100;
        public int Energy => _energy;

        private double _score = 0.0;
        public double Score => _score;

        public static event Message MessageDie;
        public static Action<string> LogMessage;

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            LogMessage += Journal.AddMessageToConsole;
            LogMessage += Journal.AddMessageToLogFile;
            LogMessage?.Invoke($"Start NEW GAME: Energy: {_energy}, Score: {_score}");
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
            LogMessage?.Invoke($"Total score: {_score}");
            LogMessage?.Invoke("Ship destroyed. GAME OVER!");
            MessageDie?.Invoke();
        }

        public void ReduceEnergy(int n)
        {
            _energy -= n;
            LogMessage?.Invoke($"Energy: {_energy}");
        }

        public void IncreaseEnergy(int n)
        {
            _energy += n;
            LogMessage?.Invoke($"Energy: {_energy}");
        }

        public void AddScore()
        {
            _score += 1.0;
            if (_score % 10 == 0)
                LogMessage?.Invoke($"Score: {_score}");
        }
    }
}
