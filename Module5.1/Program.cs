using System;
using System.IO;

namespace Module5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //create dir
                var directory = CreateNewDirectory("TestDir");
                var filePath = directory.ToString() + "\\TestFile.txt";
                var secondFilePath = directory.ToString() + "\\TestFileNew.txt";
                var thirdFilePath = directory.ToString() + "\\TestFile3.txt";
                var fourthFilePath = directory.ToString() + "\\TestFile4.txt";

                //create file
                CreateFirstFile(filePath);

                //write to file
                WriteToFirstFile(filePath);

                //read from file and write to new one
                string text = ReadAndWriteToSecondFile(filePath, secondFilePath);

                //write to 3d file
                CreateAndWriteToThirdFile(thirdFilePath, text);

                //write to 4th file
                File.WriteAllText(fourthFilePath, text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void CreateAndWriteToThirdFile(string thirdFilePath, string text)
        {
            var thirdFile = new FileInfo(thirdFilePath);
            if (thirdFile.Exists)
            {
                throw new Exception("Third file allready exists.");
            }
            thirdFile.Create().Close();
            thirdFile.AppendText().WriteLine(text);
        }

        private static string ReadAndWriteToSecondFile(string filePath, string secondFilePath)
        {
            string text;
            using (var streamReader = new StreamReader(filePath))
            using (var streamWriter = new StreamWriter(secondFilePath))
            {
                text = streamReader.ReadToEnd();
                streamWriter.WriteLine(text);
            }

            return text;
        }

        private static void WriteToFirstFile(string filePath)
        {
            using (var streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine("Lorem ipsum|Lorem ipsum|Lorem ipsum|");
            }
        }

        private static void CreateFirstFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                throw new Exception("File allready exists.");
            }
            File.Create(filePath).Close();
        }

        private static DirectoryInfo CreateNewDirectory(string name)
        {
            var directory = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + name);
            if (directory.Exists)
            {
                throw new Exception("Dir exist allready.");
            }
            directory.Create();
            return directory;
        }
    }
}
