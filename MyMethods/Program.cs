using System;

namespace MyMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MyMethods.Find(new[] { "Test", "Vasa" }, el => el.Contains("s")));
            Console.WriteLine(MyMethods.FindLast(new[] { "Vasa", "Kate", "Test" }, el => el.Contains("t")));
            Console.WriteLine(MyMethods.FindIndex(new[] { "Vasa", "Kate", "Test" }, el => el.ToLower().Contains("t")));
            Console.WriteLine(MyMethods.FindLastIndex(new[] { "Vasa", "Kate", "Test" }, el => el.ToLower().Contains("s")));
            MyMethods.FindAll(new[] { "Vasa", "Kate", "Test" }, el => el.ToLower().Contains("s")).ForEach(el => Console.WriteLine(el));
            Console.WriteLine(MyMethods.Exists(new[] { "Vasa", "Kate", "Test" }, el => el.ToLower().Contains("m")));
            Console.WriteLine(MyMethods.TrueForAll(new[] { "Vasae", "Kates", "Test" }, el => el.ToLower().Contains("s")));
        }
    }
}
