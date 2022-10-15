namespace Console_Snake;
public class Snake
{
    public ConsoleColor Color = ConsoleColor.White;
    public ConsoleKey Direction { get; set; } = ConsoleKey.RightArrow;
    public List<(int X, int Y)> PositionList { get; set; } = new(new (int X, int Y)[150]);
    public int Parts { get; set; } = 5;
    public int Speed { get; set; } = 220;

    public Snake()
    {
        PositionList[0] = (15, 15);
    }

    /// <summary>
    /// Writing the part of the snake
    /// </summary>
    /// <param name="position"></param>
    /// <param name="isHead"></param>
    public void WriteNextMove((int X, int Y) position, bool isHead)
    {
        if (isHead)
        {
            Board.Write(position, ConsoleColor.Red, '■');
            return;
        }

        Board.Write(position, Color, '■');
    }

    /// <summary>
    /// Removing last location of the snake
    /// </summary>
    /// <param name="position"></param>
    public void RemoveLastMove()
    {
        if (PositionList[Parts - 1].X != 0 || PositionList[Parts - 1].Y != 0)
        {
            Board.Write((PositionList[Parts - 1].X, PositionList[Parts - 1].Y), Color, ' ');
        }
    }

    /// <summary>
    /// New color & difficulty based on the snake parts
    /// </summary>
    public void LevelUp()
    {
        switch (Parts)
        {
            case >= 60:
                Color = ConsoleColor.Green;
                Speed = 50;
                break;
            case >= 50:
                Color = ConsoleColor.DarkGreen;
                Speed = 80;
                break;
            case >= 40:
                Color = ConsoleColor.DarkCyan;
                Speed = 100;
                break;
            case >= 30:
                Color = ConsoleColor.Cyan;
                Speed = 140;
                break;
            case >= 20:
                Color = ConsoleColor.DarkGray;
                Speed = 160;
                break;
            case >= 10:
                Color = ConsoleColor.Gray;
                Speed = 190;
                break;
            default:
                Color = ConsoleColor.White;
                break;
        }
    }

    /// <summary>
    /// Checking the lose condition
    /// </summary>
    /// <returns></returns>
    public bool IsDead()
    {
        return PositionList.Skip(1).Contains(PositionList[0]);
    }
}