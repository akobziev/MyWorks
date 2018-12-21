using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyObjectSerializer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var json = SerializeMyObject();
            Console.WriteLine(json);
        }

        private static string SerializeMyObject()
        {
            var qaEngineer = new QaEngineer
            {
                FirstName = "Anton",
                LastName = "Kobziev",
                Age = 31,
                Email = "test@test.ua",
                Projects = new List<Project>
                {
                    new Project {Client = "Lulu", Name = "Soda"},
                    new Project {Client = "Upclick", Name = "Adavare"}
                }
            };

            return JsonConvert.SerializeObject(qaEngineer);
        }
    }
}
