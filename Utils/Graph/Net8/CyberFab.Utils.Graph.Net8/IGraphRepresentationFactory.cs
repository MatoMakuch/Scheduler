namespace CyberFab.Utils.Graph.Net8
{
    public interface IGraphRepresentationFactory<TNode, TWeight>
            where TNode : INode, IEquatable<TNode>
            where TWeight : IWeight
    {
        IGraphRepresentation<TNode, TWeight> CreateGraphRepresentation(
                ISet<TNode> nodes,
                ISet<IEdge<TNode, TWeight>> edges);
    }
}
