namespace CyberFab.Utils.Console.Net8
{
    public interface IConsoleManager
    {
        IConsoleTable<T> CreateConsoleTable<T>(string title, IList<IList<T>> values) where T : IConsoleTableElement;
    }
}
