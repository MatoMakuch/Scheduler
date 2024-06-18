using CyberFab.Utils.Structures.Net8;

namespace CyberFab.Utils.Graph.Net8
{
    public class GraphRepresentationFactory<TNode, TWeight>(
            GraphMultiplicity graphMultiplicity, 
            IMatrixFactory<TNode> matrixFactory) :
                IGraphRepresentationFactory<TNode, TWeight>
                    where TNode : INode, IEquatable<TNode>
                    where TWeight : IWeight
    {
        public GraphMultiplicity GraphMultiplicity { get; } = graphMultiplicity;

        private readonly IMatrixFactory<TNode> _matrixFactory = 
            matrixFactory ?? 
                throw new ArgumentNullException(nameof(matrixFactory));

        public IGraphRepresentation<TNode, TWeight> CreateGraphRepresentation(
                ISet<TNode> nodes,
                ISet<IEdge<TNode, TWeight>> edges)
        {
            return GraphMultiplicity switch
            {
                GraphMultiplicity.Simple => new SimpleAdjacencyMatrix<TNode, TWeight>(nodes, edges, _matrixFactory),
                _ => throw new NotImplementedException($"GraphMultiplicity {GraphMultiplicity} is not supported.")
            };
        }
    }
}
