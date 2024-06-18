namespace CyberFab.Utils.Graph.Net8
{
    public abstract class GraphBase<TNode, TWeight>(
            ISet<TNode> nodes, 
            ISet<IEdge<TNode, TWeight>> edges, 
            IGraphRepresentationFactory<TNode, TWeight> graphRepresentationFactory) : 
                IGraph<TNode, TWeight>
                    where TNode : INode, IEquatable<TNode>
                    where TWeight : IWeight
    {
        protected readonly ISet<TNode> _nodes = nodes;

        protected readonly ISet<IEdge<TNode, TWeight>> _edges = edges;

        protected readonly IGraphRepresentation<TNode, TWeight> graphRepresentation = graphRepresentationFactory
            .CreateGraphRepresentation(nodes, edges);

        public bool HasNode(TNode node)
        {
            return graphRepresentation.HasNode(node);
        }

        public IEnumerable<TNode> EnumerateNodes()
        {
            return graphRepresentation.EnumerateNodes();
        }

        public bool HasEdge(TNode start, TNode end)
        {
            return graphRepresentation.HasEdge(start, end);
        }

        public IEnumerable<IEdge<TNode, TWeight>> EnumerateEdges()
        {
            return graphRepresentation.EnumerateEdges();
        }

        public IEnumerable<IEdge<TNode, TWeight>> EnumerateIncomingEdges(TNode node)
        {
            return graphRepresentation.EnumerateIncomingEdges(node);
        }

        public IEnumerable<IEdge<TNode, TWeight>> EnumerateOutgoingEdges(TNode node)
        {
            return graphRepresentation.EnumerateOutgoingEdges(node);
        }
    }
}
