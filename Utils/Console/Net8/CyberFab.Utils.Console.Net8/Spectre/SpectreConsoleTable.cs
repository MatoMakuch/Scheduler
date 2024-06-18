using Spectre.Console;

namespace CyberFab.Utils.Console.Net8.Spectre
{
    internal class SpectreConsoleTable<T> : IConsoleTable<T>
            where T : IConsoleTableElement
    {
        private readonly Table _table;

        public SpectreConsoleTable(string title, IList<IList<T>> values)
        {
            // Get number of rows.
            int tableRowsCount = values[0].Count;

            // Check argument.
            for (int i = 1; i < tableRowsCount; i++)
            {
                if (values[i - 1].Count != values[i].Count)
                    throw new ArgumentException("Uneven number of columns");
            }

            _table = new Table();

            _table.Title(title);
            
            _table.Centered(); // Set the text centering of the table.
            _table.Border(TableBorder.Rounded);
            _table.BorderColor(Color.DarkOliveGreen1);

            // Add columns.
            for (int i = 0; i < tableRowsCount; i++)
            {
                _table.AddColumns($"{i}");
            }

            // Add rows.
            for (int j = 0; j < tableRowsCount; j++)
            {
                string[] paramsValues = values[j]
                    .Select(value => value.DisplayValue)
                    .ToArray();
                _table.AddRow(paramsValues);
            }

            // Render the table to the console.
            AnsiConsole.Write(_table);
        }
    }
}
