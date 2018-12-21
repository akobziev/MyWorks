using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinqHomeTask1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arrayInts1 = { 1, 2, 3, 4, 5, 6, 7, 8, };
            int[] arrayInts2 = { 3, 4, 5, 6, 7, 8, 9, 10, };

            var str1 = "abcde";
            var str2 = "cdeim";
            var vovels = "a, e, i, o, u, y";

            // 1
            var res1 = arrayInts1.Intersect(arrayInts2).Min();

            // 2
            var res2 = arrayInts1.Intersect(arrayInts2).Where(el => el % 2 == 0).OrderBy(el => el).ElementAt(2);

            // 3
            var res3 = arrayInts1.Except(arrayInts2).Max();

            // 4
            var res4 = arrayInts1.Intersect(arrayInts2).All(el => el > 0);

            // 5
            var res5 = str1.Intersect(str2).Any();

            // 6
            var res6 = str1.Intersect(str2).Any(c => vovels.Contains(c));
        }

        #region Paging

        private static void WorkWithPaging()
        {
            foreach (var item in Paging(new[] { "a", "b", "c", "d", "e", "i" }, 2, 3).ToList())
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<T> Paging<T>(IEnumerable<T> array, int elementsOnPage, int currPage)
        {
            return array.Skip(elementsOnPage * (currPage - 1)).Take(elementsOnPage);
        }

        #endregion
    }
}
