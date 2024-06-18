namespace CyberFab.Utils.Console.Net8
{
    public interface IConsoleTableElement
    {
        string DisplayValue { get; }
        ConsoleColor ForegroungColor { get; }
        ConsoleColor BackgroundColor { get; }
    }
}
