using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Wall wall = new Wall();
            wall.Draw();
            List<Point> wallBody = new List<Point>();
            StreamReader sr = new StreamReader(@"C:\Users\Адиль\Desktop\PP2_LABS\Snake\Level1.txt");
            for (int i = 0; i < 23; i++)
            {
                string s = sr.ReadLine();
                for (int j = 0; j < s.Length; j++)
                    if (s[j] == '#')
                        wallBody.Add(new Point(j, i));
            }
            foreach (Point point in wallBody)
            {
                Console.SetCursorPosition(point.x, point.y);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("#");
            }
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 31);
            Snake snake = new Snake();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(4, 3);
            Console.WriteLine('O');
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(3, 3);
            Console.WriteLine('O');
            Console.SetCursorPosition(2, 3);
            Console.WriteLine('O');
            Food food = new Food();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(food.x, food.y);
            Console.WriteLine('@');
            while (true)
            {
                int x = 0, y = 0;
                ConsoleKeyInfo k = new ConsoleKeyInfo();
                k = Console.ReadKey();
                if ((k.Key == ConsoleKey.UpArrow || k.Key == ConsoleKey.W))
                    y = -1;
                if ((k.Key == ConsoleKey.DownArrow || k.Key == ConsoleKey.S))
                    y = 1;
                if ((k.Key == ConsoleKey.LeftArrow || k.Key == ConsoleKey.A))
                    x = -1;
                if (k.Key == ConsoleKey.RightArrow || k.Key == ConsoleKey.D)
                    x = 1;
                if (snake.body[0].x == food.x && snake.body[0].y == food.y)
                {
                    snake.AddToBody();
                    food.NewPosition(snake.body, wall.body);
                }
                snake.Move(x, y);
                if (snake.CheckGame(wall.body))
                    break;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                wall.Draw();
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(food.x, food.y);
                Console.WriteLine("@");
                snake.Draw();
            }
            Console.Clear();
            Console.SetCursorPosition(50, 15);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("GAME OVER!!!");
            Console.ReadKey();
        }
    }
}
