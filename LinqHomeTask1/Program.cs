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
            //WorkWithPaging();
            List<string> vs = new List<string> {"afdsf", "fdasff", "fffffdasf", "fffffdasf" };
            var res = vs.MySelectMany(s => s.ToUpper()).Where(c => c != 'A').ToList();

            var res1 = vs.GroupBy(s => s.Length);
            foreach (var item in res1)
            {
                Console.WriteLine(item.Key);
                foreach (var c in item)
                {
                    Console.WriteLine(c);
                }
            }
            var res2 = vs.Aggregate((acc, s) => acc + s);
            foreach (var item in res2)
            {
                Console.WriteLine(item);
            }
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
