using System;
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
            List<TResult> res = new List<TResult>();
            foreach (var item in source)
            {
                res.AddRange(selector(item));
            }
            return (IEnumerable<TResult>)res;
        }

        //public static IEnumerable<IGrouping<TKey, TSource>> MyGroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        //{
        //    foreach (var item in source)
        //    {
        //        var res = new KeyValuePair<TKey, TSource>(selector(item), item);
        //        yield return res;
        //    }
        //}
    }
}
