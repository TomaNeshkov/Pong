
namespace Pong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var field = new Field(width: 51, height: 15); 
            var left = new Racket(x: 5, y: 1);
            var right = new Racket(x: 5, y: field.GetCols-2);
            var ball = new Ball(x: field.GetRows / 2, y: field.GetCols / 2);

            left.Draw(field);
            right.Draw(field);
            ball.Draw(field);

            Console.SetWindowSize(width: field.GetCols + 1, height: field.GetRows + 3);
            Console.CursorVisible = false;

            int leftScore = 0;
            int rightScore = 0;
            DrawScore(field, leftScore, rightScore);

            int skipBall = 2;
            while (true)
            {
                DrawField(field);
                ReadInput(field, left, right);

                int score = CheckForGoal(field, ball);
                if (score != 0)
                {
                    if (score < 0)
                    {
                        leftScore++;
                    }
                    else
                    {
                        rightScore++;
                    }
                    DrawScore(field, leftScore, rightScore);
                    ball.Reset(field);
                    left.Reset(field);
                    right.Reset(field);
                }

                skipBall--;
                if (skipBall == 0)
                {
                    ball.CalculateTrajectory(field, left.Tile);
                    skipBall = 2;
                }

                Thread.Sleep(millisecondsTimeout: 10);
            }
        }

        private static void DrawScore(Field field, int leftScore, int rightScore)
        {
            DrawAt(x: field.GetRows + 1, y: 1, s: $"Player Left Score: {leftScore}");
            DrawAt(x: field.GetRows + 2, y: 1, s: $"Player Right Score: {rightScore}");
        }

        static void DrawField(Field field)
        {
            for (int i = 0; i < field.GetRows; i++)
            {
                for (int j = 0; j < field.GetCols; j++)
                {
                    DrawAt(x: i, y: j, s: field.Get(row: i, col: j).ToString());
                }
            }
        }

        static void DrawAt(int x, int y, string s)
        {
            Console.SetCursorPosition(left: y, top: x);
            Console.WriteLine(s);
        }

        static void ReadInput(Field field, Racket left, Racket right)
        {
            if (!Console.KeyAvailable)
            {
                return;
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    left.MoveUp(field);
                    break;
                case ConsoleKey.S:
                    left.MoveDown(field);
                    break;
                case ConsoleKey.UpArrow:
                    right.MoveUp(field);
                    break;
                case ConsoleKey.DownArrow:
                    right.MoveDown(field);
                    break;
            }
        }

        static int CheckForGoal(Field field, Ball ball)
        {
            if (ball.Y == 0)
            {
                return 1;
            }

            if (ball.Y == field.GetCols - 1)
            {
                return -1;
            }

            return 0;
        }
    }
}
