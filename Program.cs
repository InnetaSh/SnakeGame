using SnakeGame;
using System.Threading;
using static SnakeGame.Board;
using System;
using System.IO;

Board board = new Board(2, 2, 2);
Menu();

void Game()
{
    Console.WriteLine("Enter your name");
    var name = Console.ReadLine();

    Direction direction = Direction.Right;
    var flag = true;
    while (flag)
    {
      
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
        Thread.Sleep(200);

        board.SnakeMove(direction);
        board.Print();
        

        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            key.KeyChar.ToString().ToUpper();
            switch (key.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    direction = Direction.Up;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    direction = Direction.Down;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    break;
                case ConsoleKey.Escape:
                    return;
                case ConsoleKey.Enter:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Pause 5sec");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Pause 4sec");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Pause 3sec");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Pause 2sec");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Pause 1sec");
                    Thread.Sleep(1000);
                    break; 

                default:
                    direction = Direction.Right;
                    break;
            }
            
        }

        if (board.gameOver == true)
        {
            flag = false;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("GAME OVER :(");
            Console.WriteLine($"score: {board.score}");
            Thread.Sleep(500);

            

            string filePath = "score.txt"; 
            

            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{name, -15} | {board.score.ToString(),10}");
                    writer.WriteLine(new string('-', 36));
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении счета в файл: {ex.Message}");
            }
        }
   

    }

}

void ReadFile()
{
    string filePath = "score.txt";

    if (File.Exists(filePath))
    {
        using (var reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line); 
            }
        }
    }
    else
    {
        Console.WriteLine($"Файл {filePath} не найден.");
    }
}

void Menu()
{
    Console.WriteLine("Выберите раздел меню");
    Console.WriteLine("1 - посмотреть счет");
    Console.WriteLine("2 - играть");
    Console.WriteLine("3 - выход");
    Console.WriteLine("------------------------------------");
    int input;
    while (!Int32.TryParse(Console.ReadLine(), out input) || input < 1 || input > 3)
    {
        Console.WriteLine("Не верный ввод.Введите номер меню:");
    }
    switch (input)
    {
        case 1:
            Console.Clear();
            ReadFile();
            Console.WriteLine("Нажмите Enter для выхода в меню ");
            Console.ReadLine();
            Console.Clear();
            Menu();
            break;
        case 2:
            Console.Clear();
            Game();
            Console.Clear();
            Menu();
            break;
        case 3:
            break;
    }
    Console.Clear();
    
}

