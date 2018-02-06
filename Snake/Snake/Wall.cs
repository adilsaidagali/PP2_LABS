using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Wall
    {
        public List<Point> body;
        public Wall()
        {
            body = new List<Point>();
        }
        public void LoadLevel(int level)
        {
            Console.Clear();
            body.Clear();
            string path = @"C:\Users\Адиль\Desktop\PP2_LABS\Snake\Level";
            path += level.ToString() + ".txt";
            StreamReader sr = new StreamReader(path);
            for (int i = 0; i < 23; i++)
            {
                string s = sr.ReadLine();
                for (int j = 0; j < s.Length; j++)
                    if (s[j] == '#')
                        body.Add(new Point(j, i));
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(4, 3);
            Console.WriteLine('O');
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(3, 3);
            Console.WriteLine('O');
            Console.SetCursorPosition(2, 3);
            Console.WriteLine('O');
            Console.SetCursorPosition(0, 23);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Score: ");
            Console.Write(0);
            sr.Close();
        }
        public void Draw()
        {
            foreach(Point point in body)
            {
                Console.SetCursorPosition(point.x, point.y);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("#");
            }
        }
    }
}
