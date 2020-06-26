using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CatchItUI
{
    public class Particle
    {
        private int _x { get; set; }
        private int _y { get; set; }
        private ConsoleColor _color { get; set; }
        private static List<Particle> _particles { get; set; } = new List<Particle>();
        private static int Point { get; set; }
        public static int Limit { get; private set; } = 3;
        public static void Create(int count = 10)
        {
            for (int i = 0; i < count; i++)
            {
                _particles.Add(new Particle
                {
                    _x = RandomNumber.Get(Window.Width),
                    _y = RandomNumber.Get(Window.Height / 2),
                    _color = RandomColor.Get()
                }); ;
            }
        }
        private static void Draw()
        {
            foreach (var particle in _particles)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(particle._x, particle._y);
                //particle color
                Console.ForegroundColor = particle._color;
                Console.Write('O');
            }
        }
        private static void Move()
        {
            var caughtParticles = new List<Particle>();
            var droppedParticles = new List<Particle>();
            foreach (var particle in _particles)
            {
                if (particle._y >= Window.Height || particle._y < 0)
                {
                    droppedParticles.Add(particle);
                }
                else
                {
                    particle._y++;
                }
                if (particle._x == Catcher._x + 1 && particle._y == Catcher._y)
                {
                    caughtParticles.Add(particle);
                    Point++;
                    ShowPoint(particle._x, particle._y - 2);
                    Thread.Sleep(200);
                }
            }
            caughtParticles.ForEach((caughtParticle) =>
            {
                _particles.Remove(caughtParticle);
            });
            droppedParticles.ForEach((droppedParticle) => 
            {
                _particles.Remove(droppedParticle);
            });
        }
        public static void Update()
        {
            Draw();
            Move();
            if (_particles.Count == 0)
            {
                Create(5);
            }
        }
        private static void ShowPoint(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x, y);
            Console.WriteLine($"Total catch = {Point}");
        }
        public static int TotalCatch()
        {
            return Point;
        }
        public static bool ReplayMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Congrats! You collected {Limit} particles");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press r to replay");
            if (char.ToLowerInvariant(Console.ReadKey().KeyChar) == 'r')
            {
                Point = 0;
                return true;
            }
            return false;
        }
    }
}
