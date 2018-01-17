using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int ans = 99999;
            foreach (string s in args)
            {
                bool t = true;
                for (int i = 2; i <= Math.Sqrt(int.Parse(s)); i++)
                    if (int.Parse(s) % i == 0)
                        t = false;
                if (t == true && int.Parse(s) != 1)
                    ans = Math.Min(ans, int.Parse(s));
            }
            Console.WriteLine(ans);
            Console.ReadKey();
        }
    }
}
