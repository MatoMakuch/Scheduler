namespace CyberFab.Utils.Graph.Net8.Exceptions
{
    public class NodeNotFoundException : Exception
    {
        public NodeNotFoundException() : base() { }

        public NodeNotFoundException(string message) : base(message) { }

        public NodeNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}