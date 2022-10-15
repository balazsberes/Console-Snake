using System.Runtime.InteropServices;

namespace Console_Snake;
public static class ConsoleSettings
{
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

    [DllImport("user32.dll")]
    private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

    private const int ScMinimize = 0xF020;
    private const int ScMaximize = 0xF030;
    private const int MfBycommand = 0x00000000;
    private const int ScSize = 0xF000;
    private const int StdInputHandle = -10;
    private const uint EnableExtendedFlags = 0x0080;
    private const uint EnableQuickEditMode = 0x0040;

    public static void Initilalization()
    {
        Console.CursorVisible = false;
 
        IntPtr consoleHandle = GetStdHandle(StdInputHandle);
        GetConsoleMode(consoleHandle, out var consoleMode);
        consoleMode &= ~EnableQuickEditMode;
        consoleMode |= EnableExtendedFlags;

        DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), ScSize, MfBycommand);
        DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), ScMinimize, MfBycommand);
        DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), ScMaximize, MfBycommand);
        SetConsoleMode(consoleHandle, consoleMode);

        Console.SetWindowSize(Board.Width+2, Board.Height+2);
        Console.SetBufferSize(Board.Width+2, Board.Height+2);
    }
}