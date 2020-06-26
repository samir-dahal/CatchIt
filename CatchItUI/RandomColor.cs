using System;
using System.Collections.Generic;
using System.Text;

namespace CatchItUI
{
    public static class RandomColor
    {
        private static List<ConsoleColor> _colors { get; set; } = new List<ConsoleColor>();
        public static ConsoleColor Get()
        {
            var colors = Enum.GetValues(typeof(ConsoleColor));
            foreach(var color in colors)
            {
                if((ConsoleColor)color == ConsoleColor.Black)
                {
                    continue;
                }
                _colors.Add((ConsoleColor)color);
            }
            return _colors[RandomNumber.Get(_colors.Count)];
        }
    }
}
