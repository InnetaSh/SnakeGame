

using System.Drawing;
using static System.Formats.Asn1.AsnWriter;

namespace SnakeGame
{
    
    internal class Snake
    {
        public List<Cell> snakeBody; 

        public Snake(int startX, int startY, int length)
        {
            snakeBody = new List<Cell>();
            for (int i = 0; i < length; i++)
            {
                snakeBody.Add(new Cell(startX - i, startY));
            }
        }

        public bool HitSelf()
        {
            Cell head = snakeBody[0];
            for (int i = 1; i < snakeBody.Count; i++)
            {
                if (head.X == snakeBody[i].X && head.Y == snakeBody[i].Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
