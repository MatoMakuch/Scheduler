using CyberFab.Utils.Graph.Net8.Exceptions;

namespace CyberFab.Utils.Graph.Net8
{
    public interface IGraphBuilder<TNode, TWeight>
            where TNode : INode
            where TWeight : IWeight
    {
        /// <summary>
        /// Adds a node to the graph.
        /// </summary>
        /// <param name="node">The node to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when the node is null.</exception>
        void AddNode(TNode node);

        /// <summary>
        /// Removes a node from the graph.
        /// </summary>
        /// <param name="node">The node to remove.</param>
        /// <exception cref="ArgumentNullException">Thrown when the node is null.</exception>
        /// <exception cref="NodeNotFoundException">Thrown when the node is not found in the graph.</exception>
        void RemoveNode(TNode node);

        /// <summary>
        /// Adds an edge to the graph.
        /// </summary>
        /// <param name="start">The starting node of the edge.</param>
        /// <param name="end">The ending node of the edge.</param>
        /// <param name="weight">The weight of the edge.</param>
        /// <exception cref="ArgumentNullException">Thrown when the start or end node is null.</exception>
        /// <exception cref="NodeNotFoundException">Thrown when either the start or the end node is not found in the graph.</exception>
        /// <exception cref="EdgeAlreadyExistsException">Thrown when the edge already exists in the graph.</exception>
        void AddEdge(TNode start, TNode end, TWeight weight);

        /// <summary>
        /// Removes an edge from the graph.
        /// </summary>
        /// <param name="start">The starting node of the edge.</param>
        /// <param name="end">The ending node of the edge.</param>
        /// <exception cref="ArgumentNullException">Thrown when the start or end node is null.</exception>
        /// <exception cref="NodeNotFoundException">Thrown when either the start or the end node is not found in the graph.</exception>
        /// <exception cref="EdgeNotFoundException">Thrown when the edge is not found in the graph.</exception>
        void RemoveEdge(TNode start, TNode end);

        IGraph<TNode, TWeight> Build();
    }
}
