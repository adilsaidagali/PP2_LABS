using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int ansMin = 9999, ansMax= -9999;
            StreamReader sr = new StreamReader(@"C:\Users\Адиль\Desktop\PP2_LABS\Lab2\input.txt");
            string ss = sr.ReadToEnd();
            string[] arguments = ss.Split(' ');
            foreach (String s in arguments)
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
