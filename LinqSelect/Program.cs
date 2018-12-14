using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSelect
{
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (var number in new[] { "adfasf", "sdfdf", "dfdfv", "aaaadf" }.MySelect(s => s.ToUpper()))
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        private static IEnumerable<string> GetWithoutVowels(IEnumerable<string> strings)
        {
            var pattern = new HashSet<char>("aeiouy".ToCharArray());
            return strings.Select(s => s).Where(s => s.All(c => !pattern.Contains(c)));
        }

        private static IEnumerable<int> GetFloatToInt(IEnumerable<float> floats)
        {
            return floats.Select(f => (int) f);
        }

        private static IEnumerable<bool> GetBoolSequence(IEnumerable<int> nums)
        {
            return nums.Select(n => n > 0);
        }

        private static IEnumerable<int> PositiveNumbers(IEnumerable<int> nums)
        {
            return nums.Select(n => n < 0? -n: n);
        }
    }
}
