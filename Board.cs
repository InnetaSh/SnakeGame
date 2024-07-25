using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace SnakeGame
{
    internal class Board
    {
        public static int Size = 20;
        public Cell[,] CellMas = new Cell[Size, Size];

        public Snake snake;
        public Cell food;
        private Random random;
        public bool gameOver = false;
        public int score = 0;


        public Board(int snakeStartX, int snakeStartY, int snakeLength)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    CellMas[i, j] = new Cell(i, j);
            }

            snake = new Snake(snakeStartX, snakeStartY, snakeLength);
            random = new Random();
            PlaceFood();

        }
      

        public void PlaceFood()
        {
            int x = random.Next(0, Size);
            int y = random.Next(0, Size);
            food = new Cell(x, y);

            bool flag = false;
            while (!flag)
            {
                for (int i = 1; i < snake.snakeBody.Count; i++)
                {
                    if (x == snake.snakeBody[i].X && y == snake.snakeBody[i].Y)
                    {
                        x = random.Next(0, Size);
                        y = random.Next(0, Size);
                        food = new Cell(x, y);
                    }
                   
                }
                flag = true;
            }
        }

        public void UpdateSnake(object state)
        {
            if (!gameOver)
            {
                SnakeMove(Direction.Right);
                Print();
            }
        }


        public void Print()
        {
            for (int i = 0; i <= Size+1; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            for (int i = 0; i < Size; i++)
            {
                Console.Write("|");
                for (int j = 0; j < Size; j++)
                {
                    
                    if (snake.snakeBody.Any(cell => cell.X == j && cell.Y == i))
                    {
                        Console.Write("O");
                    }
                    else if (food.X == j && food.Y == i)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                   
                }
                Console.Write("|");
                Console.WriteLine();
            }
            for (int i = 0; i <= Size + 1; i++)
            {

                Console.Write("-");
            }
        }




        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public void SnakeMove(Direction direction)
        {
            Cell HeadBodyCell = snake.snakeBody[0];
            int newX = HeadBodyCell.X;
            int newY = HeadBodyCell.Y;

            switch (direction)
            {
                case Direction.Up:
                    newY--;
                    break;
                case Direction.Down:
                    newY++;
                    break;
                case Direction.Left:
                    newX--;
                    break;
                case Direction.Right:
                    newX++;
                    break;
            }

            Cell newBodyCell = new Cell(newX, newY);
            snake.snakeBody.Insert(0, newBodyCell);

            if (!SnakeEat(newX, newY))
            {
                snake.snakeBody.RemoveAt(snake.snakeBody.Count - 1);
            }
            if (newX < 0 || newX >= Size || newY < 0 || newY >= Size)
            {
                gameOver = true;
            }
            if (snake.HitSelf())
            {
                gameOver = true;
            }
        }

        public bool SnakeEat(int X, int Y)
        {
            if (X == food.X && Y == food.Y)
            {
                score += 100;
                PlaceFood();
                return true;
            }
            return false;
        }
    }
}
