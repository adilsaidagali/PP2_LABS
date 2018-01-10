using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(string s in args)
            {
                bool t = true;
                for (int i = 2; i < int.Parse(s); i++)
                    if (int.Parse(s) % i == 0)
                        t = false;
                if (t == true)
                    Console.WriteLine(int.Parse(s));
            }
            Console.ReadKey();
        }
    }
}
