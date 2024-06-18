using System.Diagnostics.CodeAnalysis;

namespace CyberFab.Utils.Structures.Net8
{
    public interface IMatrix<TKey, TValue> 
            where TKey : IEquatable<TKey>
    {
        bool TryGetCell(TKey i, TKey j, [MaybeNullWhen(false)] out TValue value);

        void SetCell(TKey i, TKey j, TValue value);

        bool RemoveCell(TKey i, TKey j);

        /// <summary>
        /// Gets value for each column of the row.
        /// </summary>
        /// <param name="m">The row key.</param>
        /// <param name="skipNull">If true, skips null values.</param>
        /// <returns>An enumerable of tuples containing value and column key.</returns>
        IEnumerable<KeyValuePair<TKey, TValue>> EnumerateRow(TKey m, bool skipNull = false);

        /// <summary>
        /// Gets value for each row of the column.
        /// </summary>
        /// <param name="n">The column key.</param>
        /// <param name="skipNull">If true, skips null values.</param>
        /// <returns>An enumerable of tuples containing value and row key.</returns>
        IEnumerable<KeyValuePair<TKey, TValue>> EnumerateColumn(TKey n, bool skipNull = false);
    }
}
