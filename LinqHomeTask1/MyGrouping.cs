using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqHomeTask1
{
    public class MyGrouping<TKey, TSource> : IGrouping<TKey, TSource>
    {
        private readonly IEnumerable<TSource> elements;

        public MyGrouping(TKey key, IEnumerable<TSource> source)
        {
            Key = key;
            elements = source;
        }

        public TKey Key { get; private set; }

        public IEnumerator<TSource> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
