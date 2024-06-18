namespace CyberFab.Utils.Graph.Net8
{
    public class IntTestNode(int value) : INode
    {
        public int Value { get; set; } = value;

        public bool Equals(INode? other)
        {
            if (other is IntTestNode otherIntTestNode)
                return Value == otherIntTestNode.Value;

            return false;
        }

        public override string ToString() => Value.ToString();
    }
}