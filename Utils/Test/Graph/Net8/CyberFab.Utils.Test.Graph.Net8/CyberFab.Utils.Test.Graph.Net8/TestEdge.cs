namespace CyberFab.Utils.Graph.Net8
{
    public class TestEdge<T, K>(K start, K end) //: IEdge<T, K> where K : INode<T>
    {
        public K Start { get; set; } = start;

        public K End { get; set; } = end;
    }
}
