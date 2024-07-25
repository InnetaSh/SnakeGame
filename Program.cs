﻿using SnakeGame;
using System.Threading;
using static SnakeGame.Board;

Board board = new Board(2, 2, 2);
Game();

void Game()
{
    Console.WriteLine("Enter your name");
    var name = Console.ReadLine();

    Direction direction = Direction.Right;
    var flag = true;
    while (flag)
    {
      
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
            string lineToAdd = $"{name.ToUpper(),-20} - {board.score.ToString()}";

            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(lineToAdd);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении счета в файл: {ex.Message}");
            }
        }

        Thread.Sleep(200);
        Console.Clear();



    }

   
   
    
}

