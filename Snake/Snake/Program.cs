using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Snake
{
    class Program
    {
        static void f1(HighScores highScores)
        {
            FileStream fs = new FileStream(@"C:\Users\Адиль\Desktop\PP2_LABS\Snake\Snake\data.ser", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, highScores);
            fs.Close();
        }
        static HighScores f2()
        {
            FileStream fs = new FileStream(@"C:\Users\Адиль\Desktop\PP2_LABS\Snake\Snake\data.ser", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            HighScores highScores = bf.Deserialize(fs) as HighScores;
            fs.Close();
            return highScores;
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Write("Write your login: ");
            String s = Console.ReadLine();
            HighScores Adil = new HighScores();
            HighScores highScores = f2();
            int cursor = 0, t = 0;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Start Game");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("LeaderBord");
            Console.WriteLine("Exit");
            HighScores hi = new HighScores();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                    cursor--;
                if (key.Key == ConsoleKey.DownArrow)
                    cursor++;
                if (cursor == -1)
                    cursor = 2;
                if (cursor == 3)
                    cursor = 0;
                if (cursor == 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Start Game");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("LeaderBord");
                    Console.WriteLine("Exit");
                }
                if (cursor == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Start Game");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("LeaderBord");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Exit");
                }
                if (cursor == 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Start Game");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("LeaderBord");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Exit");
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    if (cursor == 0 || cursor == 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        for (int i = 0; i < highScores.name.Count; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(highScores.name[i]);
                            Console.Write("  ");
                            Console.Write(highScores.score[i]);
                            Console.WriteLine();
                        }
                        Console.ReadKey();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Start Game");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("LeaderBord");
                        cursor = 0;
                    }
                }
            }
            bool leaveTheGame = false;
            int levelCount = 1;
            int score = 0;
            Console.SetWindowSize(100, 31);
            Snake snake = new Snake();
            Food food = new Food();
            food.x = 10;
            food.y = 10;
            Wall wall = new Wall();
            wall.LoadLevel(levelCount);
            wall.Draw();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(10, 10);
            Console.Write('@');
            int pos = -1;
            for (int i = 0; i < highScores.name.Count; i++)
            {
                if (highScores.name[i] == s)
                {
                    pos = i;
                    break;
                }
            }
            if (pos == -1)
            {
                highScores.name.Add(s);
                highScores.score.Add(0);
                pos = highScores.name.Count - 1;
            }
            while (true)
            {
                int x = 0, y = 0;
                ConsoleKeyInfo k = new ConsoleKeyInfo();
                k = Console.ReadKey();
                if (k.Key == ConsoleKey.Escape)
                    break;
                if ((k.Key == ConsoleKey.UpArrow || k.Key == ConsoleKey.W))
                    y = -1;
                if ((k.Key == ConsoleKey.DownArrow || k.Key == ConsoleKey.S))
                    y = 1;
                if ((k.Key == ConsoleKey.LeftArrow || k.Key == ConsoleKey.A))
                    x = -1;
                if (k.Key == ConsoleKey.RightArrow || k.Key == ConsoleKey.D)
                    x = 1;
                snake.Move(x, y);
                if (snake.body[0].x == food.x && snake.body[0].y == food.y)
                {
                    snake.AddToBody();
                    food.NewPosition(snake.body, wall.body);
                    score++;
                }
                if (score == 10 && levelCount == 1)
                {
                    levelCount++;
                    wall.LoadLevel(levelCount);
                    wall.Draw();
                    snake.body.Clear();
                    snake.body.Add(new Point(4, 3));
                    snake.body.Add(new Point(3, 3));
                    snake.body.Add(new Point(2, 3));
                    score = 0;
                    t = 10;
                }
                if (score == 10 && levelCount == 2)
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 10);
                    Console.WriteLine("YOU WIN!!!");
                    Console.SetCursorPosition(15, 11);
                    Console.WriteLine("Press ENTER to restart the game");
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("Press ESCAPE to leave the game");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Iliyas PEDIK");
                    while (true)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Escape)
                        {
                            leaveTheGame = true;
                            break;
                        }
                        if (key.Key == ConsoleKey.Enter)
                        {
                            levelCount = 1;
                            wall.LoadLevel(levelCount);
                            wall.Draw();
                            snake.body.Clear();
                            snake.body.Add(new Point(4, 3));
                            snake.body.Add(new Point(3, 3));
                            snake.body.Add(new Point(2, 3));
                            score = 0;
                            break;
                        }
                    }
                }
                if (leaveTheGame == true)
                    break;
                if (snake.CheckGame(wall.body))
                {
                    wall.LoadLevel(levelCount);
                    wall.Draw();
                    snake.body.Clear();
                    snake.body.Add(new Point(4, 3));
                    snake.body.Add(new Point(3, 3));
                    snake.body.Add(new Point(2, 3));
                    score = 0;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(food.x, food.y);
                Console.WriteLine("@");
                snake.Draw();
                //wall.Draw();
                Console.SetCursorPosition(0, 23);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Score: ");
                Console.SetCursorPosition(7, 23);
                Console.Write(score);
                if (score + t > highScores.score[pos])
                {
                    highScores.score[pos] = score + t;
                }
            }
            /*Console.Clear();
            for (int i = 0; i < highScores.name.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(highScores.name[i]);
                Console.Write("  ");
                Console.Write(highScores.score[i]);
                Console.WriteLine();
            }
            Console.ReadKey();*/
            f1(highScores);
        }
    }
}
