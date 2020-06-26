using System;
using System.Collections.Generic;
using System.Text;

namespace CatchItUI
{
    public static class Catcher
    {
        public static int _x { get; private set; }
        public static int _y { get; private set; } = Window.Height;
        private static ConsoleKeyInfo _moveKey;
        private static void Move(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.RightArrow)
            {
                //detects right screen edge
                if(_x >= Window.Width)
                {
                    Console.Beep();
                    return;
                }
                _x++;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                //detects left screen edge
                if(_x == 0)
                {
                    Console.Beep();
                    return;
                }
                _x--;
            }
            else
            {
                //when invalid key is pressed
                Console.Beep();
            }
        }
        private static void Draw()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(_x, _y);
            Console.Write(@"\_/");
        }
        public static void Update()
        {
            Draw();
            if (!Console.KeyAvailable)
            {
                return;
            }
            _moveKey = Console.ReadKey();
            Move(_moveKey);
        }
    }
}
