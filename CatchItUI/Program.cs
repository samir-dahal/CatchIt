using System;
using System.Threading;

namespace CatchItUI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool replay = false;
            do
            { 
                //creates 10 particles by default if not specified
                Particle.Create(5);
                while (true)
                {
                    if (Particle.TotalCatch() == Particle.Limit)
                    {
                        replay = Particle.ReplayMessage();
                        break;
                    }
                    Console.Clear();
                    Catcher.Update();
                    Particle.Update();
                    Thread.Sleep(200);
                }
            } while (replay);
            Console.WriteLine("Thank you for playing CatchIt :)");
            Console.ReadKey();
        }
    }
}
