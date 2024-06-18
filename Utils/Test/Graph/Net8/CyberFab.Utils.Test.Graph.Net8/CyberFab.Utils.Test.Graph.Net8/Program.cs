using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using CyberFab.Utils.Graph.Net8;
using CyberFab.Utils.Test.Graph.Net8;

public class Program
{
    static void Main(string[] args)
    {
        // Create data.
        var data1 = 1;
        var data2 = 2;
        var data3 = 3;

        // Create nodes.
        var node1 = new IntTestNode(data1);
        var node2 = new IntTestNode(data2);
        var node3 = new IntTestNode(data3);

        //// Create edges.
        //var edge1 = new TestEdge<int, IntTestNode>(node1, node2);
        //var edge2 = new TestEdge<int, IntTestNode>(node2, node3);

        //// Creating graph.
        //var graph = new DirectedGraph<int, IntTestNode>([node1, node2, node3], [edge1, edge2]);

        //// Iterating over nodes and edges.
        //foreach (var node in graph.Nodes)
        //{
        //    Console.WriteLine($"Node: {node.Value}");
        //}

        //foreach (var edge in graph.Edges)
        //{
        //    Console.WriteLine($"Edge: {edge.Start.Value} -> {edge.End.Value}");
        //}

        //IGraphBuilder<INode, IWeight> directedGraphBuilder = new DirectedGraphBuilder<INode, IWeight>();

        //// Add nodes.
        //directedGraphBuilder.AddNode(node1);
        //directedGraphBuilder.AddNode(node2);
        //directedGraphBuilder.AddNode(node3);

        //// Create weight.
        //var weight1 = new TestWeight(3);
        //var weight2 = new TestWeight(5);
        //var weight3 = new TestWeight(7);

        //// Add edges.
        //directedGraphBuilder.AddEdge(node1, node2, weight1);
        //directedGraphBuilder.AddEdge(node2, node3, weight1);
        //directedGraphBuilder.AddEdge(node3, node1, weight1);
    }
}