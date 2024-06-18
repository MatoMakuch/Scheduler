namespace CyberFab.Utils.Graph.Net8.Exceptions
{
    public class EdgeNotFoundException : Exception
    {
        public EdgeNotFoundException() : base() { }

        public EdgeNotFoundException(string message) : base(message) { }

        public EdgeNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}