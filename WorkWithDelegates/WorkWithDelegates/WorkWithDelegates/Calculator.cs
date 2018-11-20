using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDelegates
{
    public delegate double DoMath(int i, int j);

    public class Calculator
    {
        public static double DoSum(int i, int j)
        {
            Console.WriteLine(i + j);
            return i + j;
        }

        public static double DoSubtraction(int i, int j)
        {
            Console.WriteLine(i - j);
            return i - j;
        }

        public static double DoDivision(int i, int j)
        {
            Console.WriteLine(i / j);
            return i / j;
        }

        public static double DoMultiplication(int i, int j)
        {
            Console.WriteLine(i * j);
            return i * j;
        }
    }
}
