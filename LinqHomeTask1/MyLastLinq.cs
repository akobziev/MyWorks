using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHomeTask1
{
    public static class MyLastLinq
    {
        public static IEnumerable<TResult> MySelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (TSource item in source)
            {
                foreach (var el in selector(item))
                {
                    yield return el;
                }
            }
        }

        //public static IEnumerable<IGrouping<TKey, TSource>> MyGroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        //{
        //    foreach (var item in source)
        //    {
                
        //    }
        //}

        public static TElement Last<TElement>(this IEnumerable<TElement> source)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                // .......
            }
            return enumerator.Current;
        }

        public static TElement Last<TElement>(this IEnumerable<TElement> source, Func<TElement, bool> predicate)
        {
            TElement element = default(TElement);
            bool found = false;
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    found = true;
                    element = item;
                }
            }
            if (!found)
            {
                throw new InvalidOperationException();
            }
            return element;
        }

        public static TElement LastOrDefault<TElement>(this IEnumerable<TElement> source, Func<TElement, bool> predicate)
        {
            TElement element = default(TElement);
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    element = item;
                }
            }
            return element;
        }

    }
}