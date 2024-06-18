namespace CyberFab.Utils.Structures.Net8
{
    public interface IMatrixFactory<TKey>
        where TKey : IEquatable<TKey>
    {
        IMatrix<TKey, TValue> CreateMatrix<TValue>();
    }
}
