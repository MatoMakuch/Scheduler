using System.Collections;

namespace CyberFab.Utils.Enumerators.Net8
{
    public class PermutationIterator<T>(IList<T> values) : IEnumerator<IList<T>>, IEnumerable<IList<T>>
    {
        private bool disposedValue;

        private List<int> current = [];

        private void Swap(int i, int j) => (current[j], current[i]) = (current[i], current[j]);

        private void Flip(int i)
        {
            var temp = current.GetRange(i, current.Count - i);
            temp.Reverse();

            current.RemoveRange(i, current.Count - i);
            current.AddRange(temp);
        }

        public IList<T> Current => current.Select(index => values[index]).ToList();

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            // Initialize the iterator.
            if (current.Count == 0)
            {
                current = Enumerable.Range(0, values.Count).ToList();

                return true;
            }

            // Index of the last element that is smaller than the element to its right.
            int i = current.Count - 1;
            while (i > 0 && current[i - 1] >= current[i]) i--;
            i--;

            // No such element exists. Last permutation.
            if (i == -1)
            {
                Reset();

                return false;
            }

            // Index of the last element that is larger than the element at index i.
            int j = current.Count - 1;
            while (current[j] < current[i]) j--;

            // Find next permutation.
            Swap(i, j);
            Flip(i + 1);

            return true;
        }

        public void Reset() => current = [];

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~PermutationIterator()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public IEnumerator<IList<T>> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
