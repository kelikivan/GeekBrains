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

        static Space _backGround;
        public static BaseObject[] _objs;

        public static void Init(Form form)
        {
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;

            // Графическое устройство для вывода графики
            Graphics g = form.CreateGraphics();

            // Создаем объект (поверхность рисования) и связываем его с формой. Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

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
            for (int i = 0; i < _objs.Length; i++)
                _objs[i] = new Asteroid(new Point(600, i * 20), new Point(15-i, 15-i), new Size(20, 20));
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            _backGround.Draw();

            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            _backGround.Update();
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
    }
}