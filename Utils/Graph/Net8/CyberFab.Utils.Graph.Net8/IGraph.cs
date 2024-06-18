    namespace CyberFab.Utils.Graph.Net8
    {
        public interface IGraph<TNode, TWeight> : IGraphRepresentation<TNode, TWeight>
                where TNode : INode 
                where TWeight : IWeight
        {
            
        }
    }
