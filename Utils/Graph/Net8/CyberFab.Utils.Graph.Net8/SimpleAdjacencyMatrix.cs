using CyberFab.Utils.Graph.Net8.Exceptions;
using CyberFab.Utils.Structures.Net8;

namespace CyberFab.Utils.Graph.Net8
{
    public class SimpleAdjacencyMatrix<TNode, TWeight> : IGraphRepresentation<TNode, TWeight>
            where TNode : INode, IEquatable<TNode>
            where TWeight : IWeight
    {
        private readonly ISet<TNode> _nodes;

        private readonly ISet<IEdge<TNode, TWeight>> _edges;

        private readonly IMatrix<TNode, TWeight> _matrix;

        public SimpleAdjacencyMatrix(
                ISet<TNode> nodes,
                ISet<IEdge<TNode, TWeight>> edges,
                IMatrixFactory<TNode> matrixFactory)
        {
            ArgumentNullException.ThrowIfNull(nodes);
            ArgumentNullException.ThrowIfNull(edges);
            ArgumentNullException.ThrowIfNull(matrixFactory);

            _nodes = nodes;

            _edges = edges;

            _matrix = matrixFactory.CreateMatrix<TWeight>();

            foreach (IEdge<TNode, TWeight> edge in edges)
            {
                if (!_nodes.Contains(edge.Start))
                    throw new NodeNotFoundException($"Node {edge.Start} not found.");

                if (!_nodes.Contains(edge.End))
                    throw new NodeNotFoundException($"Node {edge.End} not found.");

                if (_matrix.TryGetCell(edge.Start, edge.End, out _))
                    throw new EdgeAlreadyExistsException($"Edge from {edge.Start} to {edge.End} already exists.");

                _matrix.SetCell(edge.Start, edge.End, edge.Weight);
            }
        }

        public bool HasNode(TNode node)
        {
            ArgumentNullException.ThrowIfNull(node);
            return _nodes.Contains(node);
        }

        public IEnumerable<TNode> EnumerateNodes()
        {
            return _nodes;
        }

        public bool HasEdge(TNode start, TNode end)
        {
            ArgumentNullException.ThrowIfNull(start);
            ArgumentNullException.ThrowIfNull(end);

            if (!_nodes.Contains(start) || !_nodes.Contains(end))
                throw new NodeNotFoundException($"Node {start} or {end} not found.");

            return _matrix.TryGetCell(start, end, out _);
        }

        public IEnumerable<IEdge<TNode, TWeight>> EnumerateEdges()
        {
            return _edges;
        }

        public IEnumerable<IEdge<TNode, TWeight>> EnumerateIncomingEdges(TNode node)
        {
            ArgumentNullException.ThrowIfNull(node);

            if (!_nodes.Contains(node))
                throw new NodeNotFoundException($"Node {node} not found.");

            foreach (KeyValuePair<TNode, TWeight> entry in _matrix.EnumerateColumn(node, true))
            {
                yield return new SimpleEdge<TNode, TWeight>
                {
                    Start = entry.Key,
                    End = node,
                    Weight = entry.Value
                };
            }
        }

        public IEnumerable<IEdge<TNode, TWeight>> EnumerateOutgoingEdges(TNode node)
        {
            ArgumentNullException.ThrowIfNull(node);

            if (!_nodes.Contains(node))
                throw new NodeNotFoundException($"Node {node} not found.");

            foreach (KeyValuePair<TNode, TWeight> entry in _matrix.EnumerateRow(node, true))
            {
                yield return new SimpleEdge<TNode, TWeight>
                {
                    Start = node,
                    End = entry.Key,
                    Weight = entry.Value
                };
            }
        }
    }
}
