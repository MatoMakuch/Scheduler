using System.Diagnostics.CodeAnalysis;

namespace CyberFab.Utils.Structures.Net8
{
    public class BiDirectionalMatrix<TKey, TValue> : IMatrix<TKey, TValue> 
            where TKey : IEquatable<TKey>
    {
        private readonly Dictionary<TKey, Dictionary<TKey, TValue>> _rows = [];

        private readonly Dictionary<TKey, Dictionary<TKey, TValue>> _columns = [];

        public bool TryGetCell(TKey i, TKey j, [MaybeNullWhen(false)] out TValue value)
        {
            if (_rows.TryGetValue(i, out var row) &&    
                    row.TryGetValue(j, out value))
                return true;
            
            value = default;
            return false;
        }

        public void SetCell(TKey i, TKey j, TValue value)
        {
            if (!_rows.TryGetValue(i, out var row))
            {
                row = [];
                _rows[i] = row;
            }
            row[j] = value;

            if (!_columns.TryGetValue(j, out var column))
            {
                column = [];
                _columns[j] = column;
            }
            column[i] = value;
        }

        public bool RemoveCell(TKey i, TKey j)
        {
            bool removed = false;

            if (_rows.TryGetValue(i, out var row) &&    
                    row.Remove(j))
            {
                if (row.Count == 0)
                    _rows.Remove(i);

                removed = true;
            }

            if (_columns.TryGetValue(j, out var column) &&
                    column.Remove(i))
            {
                if (column.Count == 0)
                    _columns.Remove(i);

                removed = true;
            }

            return removed;
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> EnumerateRow(TKey m, bool skipNull = false)
        {
            if (_rows.TryGetValue(m, out var row))
            {
                foreach (KeyValuePair<TKey, TValue> entry in row)
                {
                    if (!skipNull || entry.Value != null)
                        yield return entry;
                }
            }
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> EnumerateColumn(TKey n, bool skipNull = false)
        {
            if (_columns.TryGetValue(n, out var column))
            {
                foreach (KeyValuePair<TKey, TValue> entry in column)
                {
                    if (!skipNull || entry.Value != null)
                        yield return entry;
                }
            }
        }
    }
}
