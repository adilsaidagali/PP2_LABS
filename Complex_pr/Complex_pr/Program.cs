using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex_pr
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex ans = new Complex();
            string x = Console.ReadLine();
            string[] xx = x.Split(' ');
            int k = 0;
            foreach (string s in xx)
            {
                string[] num = s.Split('/');
                Complex c = new Complex(int.Parse(num[0]), int.Parse(num[1]));
                if (k == 0)
                    ans = c;
                else
                    ans += c;
                k = 1;
            }
            ans.Simplify();
            Console.WriteLine(ans);
            Console.ReadKey();
        }
    }
}
