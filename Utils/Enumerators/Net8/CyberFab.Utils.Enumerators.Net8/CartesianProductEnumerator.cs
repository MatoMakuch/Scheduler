using System.Collections;

namespace CyberFab.Utils.Enumerators.Net8
{
    public class CartesianProductEnumerator<T>(IEnumerable<IEnumerable<T>> values) : IEnumerator<IEnumerable<T>>, IEnumerable<IEnumerable<T>>
    {
        private bool disposedValue;

        private List<IEnumerator<T>> current = [];

        public IEnumerable<T> Current => current.Select(enumerator => enumerator.Current);

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            // Initialize the iterator.
            if (current.Count == 0)
            {
                current = values.Select(value => value.GetEnumerator()).ToList();

                foreach (var enumerator in current)
                    if (!enumerator.MoveNext())
                        return false;

                return true;
            }

            for (int i = current.Count - 1; i >= 0; i--)
            {
                if (current[i].MoveNext())
                    return true;
                else
                {
                    current[i].Reset();

                    current[i].MoveNext();
                }
            }

            Reset();

            return false;
        }

        public void Reset() => current = [];

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects)
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public IEnumerator<IEnumerable<T>> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
