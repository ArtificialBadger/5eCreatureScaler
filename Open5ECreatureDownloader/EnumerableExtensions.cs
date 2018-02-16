using System;
using System.Collections;
using System.Collections.Generic;

namespace Open5ECreatureDownloader
{
    internal static class EnumerableExtensions
    {
        internal static IEnumerable<T> ToCachedEnumerable<T>(this IEnumerable<T> enumerable)
        {
            return new CachedEnumerable<T>(enumerable);
        }

        internal sealed class CachedEnumerable<T> : IEnumerable<T>
        {
            private readonly IEnumerator<T> enumerator;
            private readonly Dictionary<int, T> cache;
            private readonly object locker = new object();

            public CachedEnumerable(IEnumerable<T> enumerable)
            {
                this.enumerator = enumerable.GetEnumerator();
                this.cache = new Dictionary<int, T>();
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new CachedEnumerator<T>(enumerator, cache, locker);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new CachedEnumerator<T>(enumerator, cache, locker);
            }
        }

        internal sealed class CachedEnumerator<T> : IEnumerator<T>
        {
            private readonly object locker;
            private IEnumerator<T> enumerator;
            private Dictionary<int, T> cache;
            private int cursor;

            public CachedEnumerator(IEnumerator<T> enumerator, Dictionary<int, T> cache, object locker)
            {
                this.locker = locker;
                this.enumerator = enumerator;
                this.cache = cache;
                this.cursor = -1;
            }

            public T Current
            {
                get
                {
                    lock (locker)
                    {
                        if (cursor >= 0)
                        {
                            return cache[cursor];
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                    }
                }
            }

            object IEnumerator.Current
            {
                get

                {
                    return Current;
                }
            }

            public void Dispose()
            {
                cache?.Clear();
                enumerator?.Dispose();

                cache = null;
                enumerator = null;
            }

            public bool MoveNext()
            {
                lock (locker)
                {
                    var nextInteger = ++cursor;

                    if (!cache.ContainsKey(nextInteger))
                    {
                        if (this.enumerator.MoveNext())
                        {
                            cache.Add(nextInteger, this.enumerator.Current);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            public void Reset()
            {
                lock (locker)
                {
                    this.cursor = -1;
                }
            }
        }
    }
}
