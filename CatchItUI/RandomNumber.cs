using System;
using System.Collections.Generic;
using System.Text;

namespace CatchItUI
{
    public static class RandomNumber
    {
        public static int Get(int max)
        {
            return new Random().Next(max);
        }
    }
}
