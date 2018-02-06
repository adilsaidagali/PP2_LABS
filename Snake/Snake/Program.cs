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
            bool leaveTheGame = false;
            int levelCount = 1;
            int score = 0;
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 31);
            Snake snake = new Snake();
            Food food = new Food();
            food.x = 10;
            food.y = 10;
            Wall wall = new Wall();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(10, 10);
            Console.WriteLine('@');
            wall.LoadLevel(levelCount);
            wall.Draw();
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
                if (score == 3 && levelCount == 1)
                {
                    levelCount++;
                    wall.LoadLevel(levelCount);
                    wall.Draw();
                    snake.body.Clear();
                    snake.body.Add(new Point(4, 3));
                    snake.body.Add(new Point(3, 3));
                    snake.body.Add(new Point(2, 3));
                    score = 0;
                }
                if (score == 3 && levelCount == 2)
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 10);
                    Console.WriteLine("YOU WIN!!!");
                    Console.SetCursorPosition(15, 11);
                    Console.WriteLine("Press ENTER to restart the game");
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("Press ESCAPE to leave the game");
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
            }
        }
    }
}
