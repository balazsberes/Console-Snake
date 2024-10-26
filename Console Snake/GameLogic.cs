namespace Console_Snake;

public class GameLogic
{
    private readonly Snake _snake;

    public GameLogic(Snake snake)
    {
        _snake = snake;
    }

    /// <summary>
    /// Get the new direction for the snake
    /// </summary>
    public void Input()
    {
        if (!Console.KeyAvailable) return;
        var keyInfo = Console.ReadKey(true);
        switch (keyInfo.Key)
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                if (_snake.Direction != ConsoleKey.S && _snake.Direction != ConsoleKey.DownArrow)
                {
                    _snake.Direction = keyInfo.Key;
                }
                break;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                if (_snake.Direction != ConsoleKey.W && _snake.Direction != ConsoleKey.UpArrow)
                {
                    _snake.Direction = keyInfo.Key;
                }
                break;
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                if (_snake.Direction != ConsoleKey.A && _snake.Direction != ConsoleKey.LeftArrow)
                {
                    _snake.Direction = keyInfo.Key;
                }
                break;
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                if (_snake.Direction != ConsoleKey.D && _snake.Direction != ConsoleKey.RightArrow)
                {
                    _snake.Direction = keyInfo.Key;
                }
                break;
        }
    }

    /// <summary>
    /// The whole GamePlay
    /// </summary>
    public void GamePlay()
    {
        EatingFruit();
        _snake.RemoveLastMove();
        MoveTheSnake();
        DisplaySnakeMovement();
    }

    /// <summary>
    /// The snake is eating a fruit
    /// </summary>
    private void EatingFruit()
    {
        // The snake is not eating the food
        if (_snake.PositionList[0].X != Fruit.Position.X || _snake.PositionList[0].Y != Fruit.Position.Y) return;

        _snake.Parts++;
        _snake.LevelUp();

        while (true)
        {
            var randomX = new Random().Next(3, Board.Width - 1);
            var randomY = new Random().Next(3, Board.Height - 1);

            // If the generated food is inside the snake positions - it's not ok
            if (_snake.PositionList.Contains((randomX, randomY))) continue;

            Fruit.Position = (randomX, randomY);
            Fruit.WriteFood();
            break;
        }
    }

    /// <summary>
    /// Moving the snake in the memory
    /// </summary>
    private void MoveTheSnake()
    {
        for (var i = _snake.Parts; i > 1; i--)
        {
            _snake.PositionList[i - 1] = (_snake.PositionList[i - 2].X, _snake.PositionList[i - 2].Y);
        }

        switch (_snake.Direction)
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                if (_snake.PositionList[0].Y - 1 != 2)
                {
                    _snake.PositionList[0] = (_snake.PositionList[0].X, _snake.PositionList[0].Y - 1);
                }
                else
                {
                    _snake.PositionList[0] = (_snake.PositionList[0].X, Board.Height - 1);
                }
                break;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                if (_snake.PositionList[0].Y + 1 != Board.Height)
                {
                    _snake.PositionList[0] = (_snake.PositionList[0].X, _snake.PositionList[0].Y + 1);
                }
                else
                {
                    _snake.PositionList[0] = (_snake.PositionList[0].X, 3);
                }
                break;
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                if (_snake.PositionList[0].X + 1 != Board.Width)
                {
                    _snake.PositionList[0] = (_snake.PositionList[0].X + 1, _snake.PositionList[0].Y);
                }
                else
                {
                    _snake.PositionList[0] = (3, _snake.PositionList[0].Y);
                }
                break;
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                if (_snake.PositionList[0].X - 1 != 2)
                {
                    _snake.PositionList[0] = (_snake.PositionList[0].X - 1, _snake.PositionList[0].Y);
                }
                else
                {
                    _snake.PositionList[0] = (Board.Width - 1, _snake.PositionList[0].Y);
                }
                break;
        }
    }

    /// <summary>
    /// Writing to board the snake movement
    /// </summary>
    private void DisplaySnakeMovement()
    {
        for (var i = 0; i <= _snake.Parts - 1; i++)
        {
            if (_snake.PositionList[_snake.Parts - 1].X == 0 && _snake.PositionList[_snake.Parts - 1].Y == 0) continue;

            // The head is different color
            var isHead = i == 0;
            _snake.WriteNextMove(_snake.PositionList[i], isHead);
        }
    }
}