using System;
using System.Threading;

namespace proba2
{
    public enum Direction { Current, Up, Down, Left, Right }
    class Snake
    {
        int[] snakeX = new int[50];
        int[] snakeY = new int[50];

        int foodX;
        int foodY;
        int length = 1;
        int score = 0;
        int time = 50;
        public bool gameOver = false;
        public static Snake snake = new Snake();
        public Direction Direction { get; set; } = Direction.Right;
        ConsoleKeyInfo Info = new ConsoleKeyInfo();

        Random rand = new Random();
        Snake()
        {
            snakeX[0] = 30;
            snakeY[0] = 10;
            Console.CursorVisible = false;
            foodX = rand.Next(1, (Console.WindowWidth - 1));
            foodY = rand.Next(1, (Console.WindowHeight - 2));
        }

        public void DrawSnake(int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("O");
            }
            catch (ArgumentOutOfRangeException)
            {
                gameOver = true;
            }
        }
        public void DrawFood(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("o");
        }
        public void Game()
        {
            if (Console.KeyAvailable)
            {
                Info = Console.ReadKey(true);

                if (Info.Key == ConsoleKey.LeftArrow)
                {
                    if (Direction != Direction.Right && Direction != Direction.Left)
                        snake.Direction = Direction.Left;
                }
                if (Info.Key == ConsoleKey.RightArrow)
                {
                    if (Direction != Direction.Right && Direction != Direction.Left)
                        snake.Direction = Direction.Right;
                }
                if (Info.Key == ConsoleKey.UpArrow)
                {
                    if (Direction != Direction.Up && Direction != Direction.Down)
                        snake.Direction = Direction.Up;
                }
                if (Info.Key == ConsoleKey.DownArrow)
                {
                    if (Direction != Direction.Up && Direction != Direction.Down)
                        snake.Direction = Direction.Down;
                }

            }

            if (snakeX[0] == foodX)
            {
                if (snakeY[0] == foodY)
                {
                    length++;
                    foodX = rand.Next(2, (Console.WindowWidth - 1));
                    foodY = rand.Next(2, (Console.WindowHeight - 2));
                    score += 10;
                }
            }
            for (int i = length; i > 0; i--)
            {
                if (snakeX[0] == snakeX[i] && snakeY[0] == snakeY[i] && length > 2)
                {
                    gameOver = true;
                }
                snakeX[i] = snakeX[i - 1];
                snakeY[i] = snakeY[i - 1];
            }

            if (Direction == Direction.Left)
            {
                snakeX[0]--;
                time = 30;
            }
            else if (Direction == Direction.Right)
            {
                snakeX[0]++;
                time = 30;
            }
            else if (Direction == Direction.Up)
            {
                snakeY[0]--;
                time = 100;
            }
            else if (Direction == Direction.Down)
            {
                snakeY[0]++;
                time = 100;
            }
            for (int i = 0; i <= (length - 1); i++)
            {
                DrawSnake(snakeX[i], snakeY[i]);
                DrawFood(foodX, foodY);
            }
            Thread.Sleep(time);
        }
        public void GameIdle()
        {
            while (snake.gameOver == false)
            {
                Console.Clear();
                Console.WriteLine("Wynik: " + snake.score);
                snake.Game();
            }
            Console.Clear();
            Console.WriteLine("\nPrzegrales! Twój wynik to: " + snake.score + " punktow");
            Console.Read();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("                                 _            ");
            Console.WriteLine("                 ___ _ __   __ _| | _____     ");
            Console.WriteLine("  __            / __| '_ \\ / _` | |/ / _ \\  ");
            Console.WriteLine(" {OO}           \\__ \\ | | | (_| |   <  __/  ");
            Console.WriteLine(" \\__/           |___/_| |_|\\__,_|_|\\_\\___|");
            Console.WriteLine("  |^|                                                       ");
            Console.WriteLine("  | |                                                       ");
            Console.WriteLine("  |^|   Program wykonała Weronika Czajkowska (303144)   /\\ ");
            Console.WriteLine("  | |__________________________________________________/ /  ");
            Console.WriteLine("  \\____/___/___/___/___/___/___/___/___/___/___/___/____/\n");
            Console.WriteLine("                      ZASADY GRY:                         \n");
            Console.WriteLine(" + celem gry jest zdobycie jak najwyzszego wyniku           ");
            Console.WriteLine(" + za kazdy zjedzony pokarm otrzymuje sie 10 punktow        ");
            Console.WriteLine(" + sterowanie wezem odbywa sie za pomoca klawiszy strzalek  ");
            Console.WriteLine(" + koniec gry nastepuje w momencie wyjscia poza okno konsoli \n   lub w momencie zetkniecia glowy z cialem weza ");
            Console.WriteLine("\n     Aby rozpoczac gre wcisnij przycisk <Spacja>        \n");

            if (Console.ReadKey().Key == ConsoleKey.Spacebar)

                Console.WriteLine("                      --- 3 ---");
            Thread.Sleep(800);
            Console.WriteLine("                       --- 2 ---");
            Thread.Sleep(800);
            Console.WriteLine("                       --- 1 ---");
            Thread.Sleep(800);
            snake.GameIdle();
        }
    }
}
