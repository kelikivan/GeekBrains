using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KelikGame
{
    static class Game
    {
        const int MAX_HEIGHT = 1000, MAX_WIDTH = 1000;

        static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        static DateTime _dateTime { get; set; }
        static readonly Timer _timer = new Timer() { Interval = 100 };
        static readonly Timer _medicineTimer = new Timer() { Interval = 15000 };
        static readonly Random Rnd = new Random();

        // Свойства - Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        static Space _backGround;
        static BaseObject[] _objs;
        static List<Bullet> _bullets = new List<Bullet>();
        static Asteroid[] _asteroids;

        static readonly Ship _ship = new Ship(new Point(10, 350), new Point(5, 5), new Size(45, 45));
        static MedicineChest _medicineChest { get; set; }

        public static void Init(Form form)
        {
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;

            // Графическое устройство для вывода графики
            Graphics g = form.CreateGraphics();

            // Создаем объект (поверхность рисования) и связываем его с формой. Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            if (Width <= 0 )
                throw new ArgumentOutOfRangeException("Ширина не установлена");
            if (Width > 1000)
                throw new ArgumentOutOfRangeException("Превышена максимальная ширина");
            if (Height <= 0)
                throw new ArgumentOutOfRangeException("Высота не установлена");
            if (Height > 1000)
                throw new ArgumentOutOfRangeException("Превышена максимальная высота");

            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            _timer.Start();
            _dateTime = DateTime.Now;
            _timer.Tick += (sender, e) => 
            {
                Draw();
                Update();
            };

            _medicineTimer.Start();
            _medicineTimer.Tick += (sender, e) =>
            {
                AddMedicineChest();
            };

            form.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.ControlKey)
                {
                    _bullets.Add(new Bullet(
                        new Point(_ship.Rect.X + 10, _ship.Rect.Y + _ship.Rect.Height / 2),
                        new Point(4, 0),
                        new Size(4, 1)));
                }
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left) 
                    _ship.Up();
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right) 
                    _ship.Down();
            };
            Ship.MessageDie += Finish;
        }

        public static void Load()
        {
            _backGround = new Space(new Point(0, 0), new Point(2, 0), new Size(Width, Height));
            _objs = new BaseObject[40];
            _asteroids = new Asteroid[25];

            for (var i = 0; i < _objs.Length; i++)
            {
                int r = Rnd.Next(5, 50);
                _objs[i] = new Star(
                    new Point(Rnd.Next(0, Game.Width), Rnd.Next(1, Game.Height - 1)), 
                    new Point(r, r), 
                    new Size(3, 3));
            }

            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = Rnd.Next(1, 10);
                _asteroids[i] = new Asteroid(
                    new Point(Game.Width, Rnd.Next(25, Game.Height - 25)), 
                    new Point(r, r), 
                    new Size(50, 50));
            }
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            //_backGround.Draw();
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid obj in _asteroids)
                obj?.Draw();
            foreach (Bullet obj in _bullets)
                obj.Draw();

            _medicineChest?.Draw();
            _ship?.Draw();

            if (_ship != null)
            {
                Buffer.Graphics.DrawString($"Energy: {_ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString($"Score: {_ship.Score}", SystemFonts.DefaultFont, Brushes.White, 100, 0);
            }

            TimeSpan time = DateTime.Now - _dateTime;
            Buffer.Graphics.DrawString($"Time: {time.ToString(@"mm\:ss")}", SystemFonts.DefaultFont, Brushes.White, 200, 0);
            Buffer.Render();
        }

        public static void Update()
        {
            //_backGround.Update();

            foreach (BaseObject obj in _objs)
                obj.Update();

            foreach (Bullet obj in _bullets)
                obj?.Update();

            _medicineChest?.Update();
            if (!_medicineChest?.IsActive ?? false)
                _medicineChest = null;

            if (_medicineChest != null && _ship.Collision(_medicineChest))
            {
                System.Media.SystemSounds.Beep.Play();
                _ship.IncreaseEnergy(_medicineChest.Energy);
                _medicineChest = null;
            }

            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;

                _asteroids[i].Update();

                foreach(Bullet bullet in _bullets)
                {
                    if (!bullet.Collision(_asteroids[i])) continue;

                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i] = null;
                    _bullets.Remove(bullet);
                    _ship.AddScore();
                    break;
                }

                if (_asteroids[i] == null) continue;
                if (!_ship.Collision(_asteroids[i])) continue;

                _asteroids[i] = null;
                _ship.ReduceEnergy(Rnd.Next(1, 20));
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship.Die();
            }
        }

        private static void AddMedicineChest()
        {
            if (_medicineChest != null) return;

            int r = Rnd.Next(4, 10);
            _medicineChest = new MedicineChest(
                new Point(Game.Width, Rnd.Next(25, Game.Height - 25)),
                new Point(r, r),
                new Size(50, 50));
        }

        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", 
                new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
    }
}