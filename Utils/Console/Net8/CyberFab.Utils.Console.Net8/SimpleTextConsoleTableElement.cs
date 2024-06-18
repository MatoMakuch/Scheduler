namespace CyberFab.Utils.Console.Net8
{
    public class SimpleTextConsoleTableElement : IConsoleTableElement
    {
        public string DisplayValue { get; set; } = string.Empty;

        public ConsoleColor ForegroungColor => ConsoleColor.While;

        public ConsoleColor BackgroundColor => ConsoleColor.Black;

        public static implicit operator SimpleTextConsoleTableElement(string value)
        {
            return new SimpleTextConsoleTableElement 
            { 
                DisplayValue = value 
            };
        }
    }
}
