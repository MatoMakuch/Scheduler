using CyberFab.Utils.Console.Net8.Spectre;

namespace CyberFab.Utils.Console.Net8
{
    public class ConsoleManagerFactory(ConsoleManagerType consoleManagerType) : IConsoleManagerFactory
    {
        public ConsoleManagerType ConsoleManagerType { get; } = consoleManagerType;

        public IConsoleManager CreateConsoleManager()
           => ConsoleManagerType switch
           {
               ConsoleManagerType.Spectre => new SpectreConsoleManager(),
               _ => throw new NotImplementedException(),
           };
    }
}
