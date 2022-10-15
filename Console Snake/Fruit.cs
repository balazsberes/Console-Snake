namespace Console_Snake;
public class Fruit
{
    public static (int X, int Y) Position { get; set; } =  (10, 10);

    public static void WriteFood()
    {
        Board.Write(Position, ConsoleColor.Red, 'Ó');
    }
}