namespace CyberFab.Utils.Graph.Net8
{
    public class TestNode<T>(T value) //: INode<T>
    {
        public T Value { get; set; } = value;
    }
}