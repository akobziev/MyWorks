using System;
using System.IO;

namespace StreamsAndIO
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncDemo();
            FunWithAdapters();

            Console.ReadLine();
        }

        private async static void FunWithAdapters()
        {
            using (FileStream fs = File.Create(@"C:\Users\Student\Desktop\test.txt"))
            using (TextWriter writer = new StreamWriter(fs))
            {
                await writer.WriteLineAsync("Line1");
                await writer.WriteLineAsync("Line2");
            }

            using (FileStream fs = File.OpenRead(@"C:\Users\Student\Desktop\test.txt"))
            using (TextReader reader = new StreamReader(fs))
            {
                Console.WriteLine(await reader.ReadLineAsync());
                Console.WriteLine(await reader.ReadLineAsync());
            }
        }

        async static void AsyncDemo()
        {
            using (Stream s = new FileStream(@"C:\Users\Student\Desktop\test.txt", FileMode.Create))
            {
                byte[] block = { (byte)'a', (byte)'b', (byte)'c', (byte)'d' };
                await s.WriteAsync(block, 0, block.Length);

                s.Position = 0;
                Console.WriteLine(await s.ReadAsync(block, 0, block.Length));
            }
        }
    }
}
