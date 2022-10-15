using Console_Snake;

ConsoleSettings.Initilalization();
StartGame();

void StartGame()
{
    Console.Clear();
    var snake = new Snake();
    GameLogic gameLogic = new(snake);

    Board.Initialization();
    Fruit.WriteFood();

    while (true)
    {
        gameLogic.Input();
        gameLogic.GamePlay();

        if (snake.IsDead())
        {
            Board.WriteMessage("You Lost!", ConsoleColor.Red);
            Wait();
            break;
        }

        if (snake.Parts == 150)
        {
            Board.WriteMessage("You Won!", ConsoleColor.Green);
            Wait();
            break;
        }

        Thread.Sleep(snake.Speed);
    }
}

void Wait()
{
    while (true)
    {
        if (!Console.KeyAvailable) continue;
        StartGame();
        break;
    }
}