namespace CyberFab.Utils.Graph.Net8
{
    public readonly struct SimpleEdge<TNode, TWeight> : IEdge<TNode, TWeight> 
            where TNode : INode 
            where TWeight : IWeight
    {
        public TNode Start { get; init; }

        public TNode End { get; init; }

        public TWeight Weight { get; init; }

        public bool Equals(IEdge<TNode, TWeight>? other)
        {
            if (other is null)
                return false;

            return 
                Start.Equals(other.Start) && 
                End.Equals(other.End) && 
                Weight.Equals(other.Weight);
        }
    }
}
