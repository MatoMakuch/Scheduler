namespace CyberFab.Utils.Console.Net8.Spectre
{
    internal class SpectreConsoleManager : IConsoleManager
    {
        public IConsoleTable<T> CreateConsoleTable<T>(string title, IList<IList<T>> values) where T : IConsoleTableElement
            => new SpectreConsoleTable<T>(title, values);
    }
}
