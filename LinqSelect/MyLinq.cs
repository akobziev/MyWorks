using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace LinqSelect
{
    public static class MyLinq
    {
        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var s in source)
            {
                yield return selector(s);
            }
        }

        public static IEnumerable<TSource> MyUnion<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            var collect = new HashSet<TSource>();
            foreach (var source in first)
            {
                collect.Add(source);
            }
            foreach (var source in second)
            {
                collect.Add(source);
            }
            return collect;
        }

        public static IEnumerable<TSource> MyExcept<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            foreach (var f in first)
            {
                var counter = 0;
                foreach (var s in second)
                {
                    if (f.Equals(s))
                    {
                        counter++;
                    }
                }
                if (counter == 0)
                {
                    yield return f;
                }
            }
        }

        public static IEnumerable<TSource> MyIntersect<TSource>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            var res = new HashSet<TSource>();
            foreach (var f in first)
            {
                foreach (var s in second)
                {
                    if (f.Equals(s))
                    {
                        res.Add(f);
                    }
                }
            }
            return res;
        }

        public static IEnumerable<TSource> MyDistinct<TSource>(this IEnumerable<TSource> source)
        {
            var res = new HashSet<TSource>();
            foreach (var s in source)
            {
                res.Add(s);
            }
            return res;
        }

        public static TSource MyFirst<TSource>(this IEnumerable<TSource> sources)
        {
            foreach (var source in sources)
            {
                return source;
            }
            throw new InvalidOperationException();
        }

        public static TSource MyFirst<TSource>(this IEnumerable<TSource> sources, Func<TSource, bool> predicate)
        {
            foreach (var source in sources)
            {
                if (predicate(source))
                {
                    return source;
                }
            }
            throw new InvalidOperationException();
        }

        public static TSource MyFirstOrDefault<TSource>(this IEnumerable<TSource> sources)
        {
            foreach (var source in sources)
            {
                return source;
            }
            return default(TSource);
        }

        public static TSource MyFirstOrDefault<TSource>(this IEnumerable<TSource> sources,
            Func<TSource, bool> predicate)
        {
            foreach (var source in sources)
            {
                if (predicate(source))
                {
                    return source;
                }
            }
            return default(TSource);
        }

        public static TSource MyLast<TSource>(this IEnumerable<TSource> sources)
        {
            var res = sources.ToList();
            try
            {
                return res[res.Count - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }

        public static TSource MyLast<TSource>(this IEnumerable<TSource> sources, Func<TSource, bool> predicate)
        {
            var rev = sources.Reverse().ToList();
            foreach (var el in rev)
            {
                if (predicate(el))
                {
                    return el;
                }
            }
            throw new InvalidOperationException();
        }

        public static TSource MyLastOrDefault<TSource>(this IEnumerable<TSource> sources)
        {
            var res = sources.ToList();
            try
            {
                return res[res.Count - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                return default(TSource);
            }
        }

        public static TSource MyLastOrDefault<TSource>(this IEnumerable<TSource> sources, Func<TSource, bool> predicate)
        {
            var rev = sources.Reverse().ToList();
            foreach (var el in rev)
            {
                if (predicate(el))
                {
                    return el;
                }
            }
            return default(TSource);
        }

        public static TSource MyElementAt<TSource>(this IEnumerable<TSource> sources, int index)
        {
            var res = sources.ToList();
            return res[index];
        }

        public static TSource MyElementAtOrDefault<TSource>(this IEnumerable<TSource> sources, int index)
        {
            var res = sources.ToList();
            try
            {
                return res[index];
            }
            catch (ArgumentOutOfRangeException)
            {
                return default(TSource);
            }
        }

        public static TSource MySingle<TSource>(this IEnumerable<TSource> sources)
        {
            var res = sources.ToList();
            if (res.Count > 1 || res.Count < 1)
            {
                throw new InvalidOperationException();
            }
            return res[0];
        }

        public static TSource MySingle<TSource>(this IEnumerable<TSource> sources, Func<TSource, bool> predicate)
        {
            var res = sources.ToList();
            if (res.Count > 1 || res.Count < 1)
            {
                throw new InvalidOperationException();
            }
            if (predicate(res[0]))
            {
                return res[0];
            }
            throw new InvalidOperationException();
        }

        public static bool MyAny<TSource>(this IEnumerable<TSource> sources)
        {
            if (sources.GetEnumerator().MoveNext())
            {
                return true;
            }
            return false;
        }

        public static bool MyAny<TSource>(this IEnumerable<TSource> sources, Func<TSource, bool> predicate)
        {
            var enumerable = sources as IList<TSource> ?? sources.ToList();
            if (!enumerable.GetEnumerator().MoveNext())
            {
                return false;
            }
            foreach (var source in enumerable)
            {
                if (predicate(source))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool MyContains<TSource>(this IEnumerable<TSource> sources, TSource element)
        {
            foreach (var source in sources)
            {
                if (source.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public static IEnumerable<TSource> MyConcat<TSource>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            foreach (var source in first)
            {
                yield return source;
            }
            foreach (var source in second)
            {
                yield return source;
            }
        }

        public static IEnumerable<TSource> MyReverse<TSource>(this IEnumerable<TSource> sources)
        {
            var enumerable = sources as IList<TSource> ?? sources.ToList();
            for (var i = enumerable.Count - 1; i >= 0; i--)
            {
                yield return enumerable[i];
            }
        }

        public static bool MySequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            var fir = first as IList<TSource> ?? first.ToList();
            var sec = second as IList<TSource> ?? second.ToList();
            if (fir.Count() != sec.Count())
            {
                return false;
            }
            for (var i = 0; i < fir.Count(); i++)
            {
                if (!fir[i].Equals(sec[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static IEnumerable<TSource> MyDefaultIfEmpty<TSource>(this IEnumerable<TSource> sources)
        {
            if (!sources.GetEnumerator().MoveNext())
            {
                yield return default(TSource);
            }
            foreach (var source in sources)
            {
                yield return source;
            }
        }

        public static IEnumerable<TSource> MyDefaultIfEmpty<TSource>(this IEnumerable<TSource> sources,
            TSource defaultValue)
        {
            if (!sources.GetEnumerator().MoveNext())
            {
                yield return defaultValue;
            }
            foreach (var source in sources)
            {
                yield return source;
            }
        }

        public static TSource[] MyToArray<TSource>(this IEnumerable<TSource> sources)
        {
            var array = new TSource[sources.Count()];
            for (int i = 0; i < sources.Count(); i++)
            {
                array[i] = sources.ElementAt(i);
            }
            return array;
        }

        public static List<TSource> MyToList<TSource>(this IEnumerable<TSource> sources)
        {
            var list = new List<TSource>();
            foreach (var source in sources)
            {
                list.Add(source);
            }
            return list;
        }

        public static Dictionary<TKey, TSource> MyToDictionary<TSource, TKey>(this IEnumerable<TSource> sources, Func<TSource, TKey> keySelector)
        {
            var dict = new Dictionary<TKey, TSource>();
            foreach (var source in sources)
            {
                var key = keySelector(source);
                if (!dict.ContainsKey(key))
                {
                    dict[key] = source;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            return dict;
        }
    }
}
