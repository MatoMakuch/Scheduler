namespace CyberFab.Utils.Structures.Net8
{
    public class MatrixFactory<TKey>(MatrixType matrixType) 
            : IMatrixFactory<TKey>
                where TKey : IEquatable<TKey>
    {
        public MatrixType MatrixType { get; } = matrixType;

        public IMatrix<TKey, TValue> CreateMatrix<TValue>()
           => MatrixType switch
           {
               MatrixType.BiDirectional => new BiDirectionalMatrix<TKey, TValue>(),
               _ => throw new NotImplementedException(),
           };
    }
}
