using CyberFab.Utils.Console.Net8;

class Program
{
    static void Main(string[] args)
    {
        IConsoleManagerFactory consoleManagerFactory = 
            new ConsoleManagerFactory(ConsoleManagerType.Spectre);

        IConsoleManager consoleManager = consoleManagerFactory
            .CreateConsoleManager();

        string title = "Test Table";

        IList<IList<SimpleTextConsoleTableElement>> values = [];

        for (int i = 1; i <= 5; i++)
        {
            values.Add([]);

            for (int j = 1; j <= 5; j++)
            {
                values[i - 1].Add($"{i}{j}");
            }
        }

        _ = consoleManager.CreateConsoleTable<SimpleTextConsoleTableElement>(title, values);
    }
}
