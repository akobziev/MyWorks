using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.IO;

namespace MultyThreading
{
    class Program
    {
        static List<int> list = new List<int>();

        static void Main(string[] args)
        {
            //Example1();
            //Example2();
            //Example3();
            //Example4();
            //Example5();
            //Example6();
            //Example7();
            //Example8();
            //Example9();
            DisplayItWorks();
            var res = GetMostImportantAnswer();
            Console.WriteLine(res.Result);


        }

        private static void Example9()
        {
            Task<string> t = Task.Run(() =>
            {
                Console.WriteLine("Inside task.");
                return "it works";
            });

            t.ContinueWith(i =>
            {
                Console.WriteLine(i.IsCompleted);
                string res = i.Result;
                Console.WriteLine(res);
            });
            Console.ReadLine();
        }

        private static void Example8()
        {
            Task<string> t = Task.Run(() =>
            {
                Console.WriteLine("Inside task.");
                return "it works";
            });

            var awaiter = t.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                var res = awaiter.GetResult();
                Console.WriteLine(res);
            });
            Console.ReadLine();
        }

        private static void Example7()
        {
            var source = "fdfdereaarf";
            Task<int> t1 = Task.Run(() => NumOfVowels(source, 0, source.Length / 2));

            var res2 = NumOfVowels(source, source.Length / 2, source.Length);
            Console.WriteLine(t1.Result + res2);
        }

        private static void Example6()
        {
            var array = new int[] { 4, 1, 2, 5, 4, 2 };
            Task<int> t1 = Task.Run(() => Sum(array, 0, array.Length / 2));
            int res2 = Sum(array, array.Length / 2, array.Length);

            Console.WriteLine(t1.Result + res2);
        }

        private static void Example5()
        {
            Task.Run(() => Console.WriteLine("dfdsfas")).Wait();
        }

        private static void Example4()
        {
            var array = new int[] { 4, 1, 2, 5, 4, 2 };

            int res1 = 0;
            Thread t = new Thread(() => res1 = Sum(array, 0, array.Length / 2));
            t.Start();

            int res2 = Sum(array, array.Length / 2, array.Length);
            t.Join();

            Console.WriteLine(res1 + res2);
        }

        private static void Example3()
        {
            var array = new int[] { 4, 1, 2, 5, 4, 2 };

            int res1 = int.MaxValue;
            Thread t = new Thread(() => res1 = Min(array, 0, array.Length / 2));
            t.Start();

            int res2 = Min(array, array.Length / 2, array.Length);
            t.Join();

            Console.WriteLine(res1 < res2 ? res1 : res2);
        }

        private static void Example2()
        {
            Thread t = new Thread(() => Write("Test"));
            t.Start();
            t.Join();
        }

        private static void Example1()
        {
            Thread t = new Thread(Go);
            t.Start();
            for (int i = 0; i < 10000; i++)
            {
                lock (list)
                {
                    list.Add(1);
                }
            }
            t.Join();
            Console.WriteLine(list.Count);
        }

        static void Go()
        {
            for (int i = 0; i < 10000; i++)
            {
                lock (list)
                {
                    list.Add(1);
                }
            }
        }

        static void Write(string message)
        {
            Console.WriteLine(message);
        }

        static int Min(int[] array, int firstIndex, int lastIndex)
        {
            int min = int.MaxValue;
            for (int i = firstIndex; i < lastIndex; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }

        static int Sum(int[] array, int firstIndex, int lastIndex)
        {
            int sum = 0;
            for (int i = firstIndex; i < lastIndex; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        private static int NumOfVowels(string source, int startIndex, int endIndex)
        {
            return source.Skip(startIndex).Take(endIndex).Count(c => "aeiou".Contains(c));
        }

        static Task<string> GetItWorksAsync()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Inside task");
                return "It works";
            });
        }

        static async void DisplayItWorks()
        {
            Task<string> t = GetItWorksAsync();
            string res = await t;
            Console.WriteLine(res);
        }

        static async Task<int> GetMostImportantAnswer()
        {
            await Task.Delay(5000);
            int answer = 21 * 2;
            return answer;
        }

        static async Task<List<string>> ReadAllLinesFromFile()
        {
            var arr = await File.ReadAllLinesAsync("file.txt");
            List<string> res = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    res.Add(arr[i]);
                }
            }
            return res;
        }
    }
}
