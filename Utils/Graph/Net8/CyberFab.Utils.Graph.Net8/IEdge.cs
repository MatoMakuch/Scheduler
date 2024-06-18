namespace CyberFab.Utils.Graph.Net8
{
    public interface IEdge<TNode, TWeight> : IEquatable<IEdge<TNode, TWeight>>
            where TNode : INode
            where TWeight : IWeight
    {
        public TNode Start { get; }

        public TNode End { get; }

        public TWeight Weight { get; }
    }
}
