namespace CyberFab.Utils.Graph.Net8
{
    public interface IGraphRepresentation<TNode, TWeight>
            where TNode : INode
            where TWeight : IWeight
    {
        bool HasNode(TNode node);

        IEnumerable<TNode> EnumerateNodes();

        /// <summary>
        /// Determines whether an edge exists between the specified nodes.
        /// </summary>
        /// <param name="start">The starting node of the edge.</param>
        /// <param name="end">The ending node of the edge.</param>
        /// <returns><c>true</c> if the edge exists; otherwise, <c>false</c>.</returns>
        bool HasEdge(TNode start, TNode end);

        /// <summary>
        /// Enumerates all edges.
        /// </summary>
        /// <returns>An enumeration of all edges.</returns>
        IEnumerable<IEdge<TNode, TWeight>> EnumerateEdges();

        /// <summary>
        /// Enumerates incoming edges for the given node.
        /// </summary>
        /// <param name="node">The node for which to enumerate incoming edges.</param>
        /// <returns>An enumeration of incoming edges.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the node is null.</exception>
        /// <exception cref="NodeNotFoundException">Thrown when the node is not found.</exception>
        IEnumerable<IEdge<TNode, TWeight>> EnumerateIncomingEdges(TNode node);

        /// <summary>
        /// Enumerates outgoing edges for the given node.
        /// </summary>
        /// <param name="node">The node for which to enumerate outgoing edges.</param>
        /// <returns>An enumeration of outgoing edges.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the node is null.</exception>
        /// <exception cref="NodeNotFoundException">Thrown when the node is not found.</exception>
        IEnumerable<IEdge<TNode, TWeight>> EnumerateOutgoingEdges(TNode node);
    }
}
