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
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        // Свойства - Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        const int MAX_HEIGHT = 1000, MAX_WIDTH = 1000;

        static Space _backGround;
        private static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;

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

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += (sender, e) => 
            {
                Draw();
                Update();
            };
        }

        public static void Load()
        {
            _backGround = new Space(new Point(0, 0), new Point(2, 0), new Size(Width, Height));
            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(0, 200), new Point(10, 2), new Size(4, 1));
            _asteroids = new Asteroid[20];
            var rnd = new Random();
            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(
                    new Point(rnd.Next(0, Game.Width), rnd.Next(1, Game.Height - 1)), 
                    new Point(r, r), 
                    new Size(3, 3));
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(1, 10);
                _asteroids[i] = new Asteroid(
                    new Point(Game.Width, rnd.Next(30, Game.Height - 30)), 
                    new Point(r, r), 
                    new Size(41, 41));
            }
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            //_backGround.Draw();
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid obj in _asteroids)
                obj.Draw();
            _bullet.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            _backGround.Update();

            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (Asteroid a in _asteroids)
            {
                a.Update();
                if (a.Collision(_bullet)) 
                { 
                    System.Media.SystemSounds.Hand.Play();
                    a.Reset();
                    _bullet.Reset();
                }
            }
            _bullet.Update();
        }
    }
}