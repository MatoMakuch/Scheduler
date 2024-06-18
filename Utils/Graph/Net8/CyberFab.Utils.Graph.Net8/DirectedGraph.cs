
namespace CyberFab.Utils.Graph.Net8
{
    public class DirectedGraph<TNode, TWeight> : GraphBase<TNode, TWeight>, IGraph<TNode, TWeight>
            where TNode : INode, IEquatable<TNode>
            where TWeight : IWeight
    {
        public DirectedGraph(
                ISet<TNode> nodes, 
                ISet<IEdge<TNode, TWeight>> edges, 
                IGraphRepresentationFactory<TNode, TWeight> graphRepresentationFactory) : 
                    base(nodes, edges, graphRepresentationFactory)
        {

        }
    }
}
