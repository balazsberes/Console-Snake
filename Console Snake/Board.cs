namespace Console_Snake;
public class Board
{
    public const int Width = 32;
    public const int Height = 32;

    /// <summary>
    /// Initialization of the frame
    /// </summary>
    public static void Initialization()
    {
        Console.ForegroundColor = ConsoleColor.White;
        for (var i = 2; i <= Width; i++)
        {
            Console.SetCursorPosition(i, 2);
            Console.Write("═");
            Console.SetCursorPosition(i, Height);
            Console.Write("═");
        }

        for (var i = 2; i < Height; i++)
        {
            Console.SetCursorPosition(2, i);
            Console.Write("║");
            Console.SetCursorPosition(Width, i);
            Console.Write("║");
        }

        Console.SetCursorPosition(2, 2);
        Console.Write("╔");
        Console.SetCursorPosition(Width, 2);
        Console.Write("╗");
        Console.SetCursorPosition(2, Height);
        Console.Write("╚");
        Console.SetCursorPosition(Width, Height);
        Console.Write("╝");
    }

    /// <summary>
    /// Generic function to write the snake and food
    /// </summary>
    /// <param name="position"></param>
    /// <param name="color"></param>
    /// <param name="character"></param>
    public static void Write((int X, int Y) position, ConsoleColor color, char character)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(position.X, position.Y);
        Console.Write(character);
    }

    /// <summary>
    /// Win or Lose message writer
    /// </summary>
    /// <param name="text"></param>
    /// <param name="color"></param>
    public static void WriteMessage(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(13, 2);
        Console.Write(text);
    }
}