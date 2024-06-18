namespace CyberFab.Utils.Graph.Net8.Exceptions
{
    public class EdgeAlreadyExistsException : Exception
    {
        public EdgeAlreadyExistsException() : base() { }

        public EdgeAlreadyExistsException(string message) : base(message) { }

        public EdgeAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
    }
}