namespace CyberFab.Utils.Graph.Net8.Exceptions
{
    public class InvalidWeightException : Exception
    {
        public InvalidWeightException() : base() { }

        public InvalidWeightException(string message) : base(message) { }

        public InvalidWeightException(string message, Exception innerException) : base(message, innerException) { }
    }
}