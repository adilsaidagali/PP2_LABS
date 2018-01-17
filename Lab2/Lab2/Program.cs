using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int ansMin = 9999, ansMax= -9999;
            foreach(String s in args)
            {
                ansMin = Math.Min(ansMin, int.Parse(s));
                ansMax = Math.Max(ansMax, int.Parse(s));
            }
            Console.WriteLine(ansMin);
            Console.WriteLine(ansMax);
            Console.ReadKey();
        }
    }
}
