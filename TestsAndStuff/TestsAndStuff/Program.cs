using System;

namespace TestsAndStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("mm:ss"));
            var time = new TimeSpan(1, 34, 34);
            Console.WriteLine(time);
            Console.WriteLine(time.ToString("mm\\:ss."));
        }
    }
}