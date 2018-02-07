using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Complex_pr
{
    class Program
    {
        static void f1()
        {
            FileStream fs = new FileStream(@"C:\Users\Адиль\Desktop\PP2_LABS\Complex_pr\Complex_pr\data.ser", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            Complex ans = new Complex();
            bf.Serialize(fs, ans);
            fs.Close();
        }
        static Complex f2()
        {
            FileStream fs = new FileStream(@"C:\Users\Адиль\Desktop\PP2_LABS\Complex_pr\Complex_pr\data.ser", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            Complex ans = bf.Deserialize(fs) as Complex;
            fs.Close();
            return ans;
        }
        static void Main(string[] args)
        {
            Complex ans = new Complex();
            ans = f2();
            Console.WriteLine(ans);
            string x = Console.ReadLine();
            string[] xx = x.Split(' ');
            foreach (string s in xx)
            {
                string[] num = s.Split('/');
                Complex c = new Complex(int.Parse(num[0]), int.Parse(num[1]));
                if (ans.c2 == 0)
                    ans = c;
                else
                    ans += c;
            }
            ans.Simplify();
            f1();
            Console.WriteLine(ans);
            Console.ReadKey();
        }
    }
}
