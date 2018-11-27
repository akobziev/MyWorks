using ConsoleApp4;
using System;
using System.Linq;

namespace WorkWithLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            GetNumsOfManAndWomans();
            SortAndWritePersoneInfo();
            FindThowsWhoLivesInCountrys();
            FindAverageIncome();
            FindWithBiggestIncomeInCountry();
            MaxLanguages();
            FindePoliglote();
            FindeSeparatisto();
            FindeGermans();
            FindePersentOfMarried();
            FindePoligloteWithLowestRate();
            FindeSinglePhD();
            FindeSpanishPeople();
            FindePersonLivesInSmolestCity();
            Task17();
            Task18();
        }

        private static void Task18()
        {
            var result = Dataset.People.Where(p => p.AnnualIncome > (Dataset.People.Select(j => j.AnnualIncome).ToList().Max() - p.AnnualIncome));
        }

        private static void Task17()
        {
            var result = (Dataset.People.Where(p => p.Languages.Select(l => l.Name).Contains("English"))
                .Where(p => p.HomeAddress.City.Country.Language.Id != 1).Count() * 100) / Dataset.People.Count();
        }

        private static void FindePersonLivesInSmolestCity()
        {
            var result = Dataset.People.Where(p => p.HomeAddress.City.Population == Dataset.Cities.Select(c => c.Value.Population).ToList().Min());
        }

        private static void FindeSpanishPeople()
        {
            Dataset.People.Where(p => p.HomeAddress.City.Country.Language.Id == 3).ToList().ForEach(
                p => { Console.WriteLine($"{p.Name} {p.Occupation} {p.HomeAddress.City.Name} {p.HomeAddress.City.Country.Name}"); });
        }

        private static void FindeSinglePhD()
        {
            var result = Dataset.People.Where(p => p.Occupation == "PhD Student").Count() == 1 ? true : throw new Exception("Error!");
        }

        private static void FindePoligloteWithLowestRate()
        {
            var result = Dataset.People.Where(p => p.Languages.Count() >= 2 && p.AnnualIncome < p.HomeAddress.City.Country.AvgIncome);
        }

        private static void FindePersentOfMarried()
        {
            double result = ((Dataset.People.Where(p => p.FamilyStatus == FamilyStatus.Married).ToList().Count() * 100) / Dataset.People.Count());
        }

        private static void FindeGermans()
        {
            Dataset.People.Where(p => p.HomeAddress.City.Country.Name == "Germany").OrderBy(p => p.Age).Reverse().ToList().ForEach(
                p =>
                {
                    Console.WriteLine($"{p.Name} {p.SurName} {p.Age} {p.HomeAddress.City.Name}");
                });
        }

        private static void FindeSeparatisto()
        {
            var result = Dataset.People.Where(p => !p.Languages.Select(l => l.Name).ToList().Contains(p.HomeAddress.City.Country.Language.Name))??null;
        }

        private static void FindePoliglote()
        {
            var result = Dataset.People.Where(p => p.Languages.Count() == MaxLanguages());
        }

        private static int MaxLanguages()
        {
            return Dataset.People.Select(p => p.Languages.Count()).Max();
        }

        private static void FindWithBiggestIncomeInCountry()
        {
            var result = Dataset.People.Where(p => p.AnnualIncome > p.HomeAddress.City.Country.AvgIncome).ToList();
        }

        private static void FindAverageIncome()
        {
            var result = Dataset.People.Where(p => p.EducationLevel > EducationLevel.HECert).Select(p => p.AnnualIncome).Average();
        }

        private static void FindThowsWhoLivesInCountrys()
        {
            var result = Dataset.People.Where(p => p.HomeAddress.City.Country.Population > 80 * 1000000).ToList();
        }

        private static void SortAndWritePersoneInfo()
        {
            Dataset.People.OrderBy(p => p.Name).OrderBy(p => p.SurName).ToList().ForEach(
                p =>
                {
                    Console.WriteLine($"{p.Name} {p.SurName}, age {p.Age} lives in {p.HomeAddress.City}, {p.HomeAddress.City.Country}" +
                 $"{(p.Gender == Gender.Man ? "He" : "She")} is {p.Occupation} and makes {p.AnnualIncome} a year." +
                 $"{p.FamilyStatus.ToString()}, speaks {p.Languages.Count()} languages.");
                });
        }

        private static void GetNumsOfManAndWomans()
        {
            var numOfMan = Dataset.People.Where(p => p.Gender == Gender.Man).ToList().Count;
            var numOfWomans = Dataset.People.Where(p => p.Gender == Gender.Woman).ToList().Count;
        }
    }

    namespace Module4._2
    {
        public class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Occupation { get; set; }
            public Address HomeAddress { get; set; }
        }
        public class Address
        {
            public int Id { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string PostalCode { get; set; }
            public string City { get; set; }
            public string Province { get; set; }
            public Country Country { get; set; }
        }
        public class Country
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public string TelephoneCode { get; set; }
        }

        public static class DataSet
        {
            public static Person[] People = new Person[]
            {
            new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Age = 33,
                Occupation = "Dentist",
                HomeAddress = new Address
                {
                    AddressLine1 = "1 Main st",
                    PostalCode = "345 01",
                    Province = "Central Spain",
                    City = "Madrid",
                    Country = new Country()
                    {
                        Id = 1,
                        Code = "ESP",
                        Name = "Spain"
                    }
                }

            },
             new Person
            {
                Id = 1,
                FirstName = "Jane",
                LastName = "Doe",
                Age = 28,
                Occupation = "Flight Attendant",
                HomeAddress = new Address
                {
                    AddressLine1 = "4 Gross st",
                    PostalCode = "25 BA 1",
                    Province = "Bavaria",
                    City = "Munich",
                    Country = new Country()
                    {
                        Id = 2,
                        Code = "DE",
                        Name = "Germany"
                    }
                }

            },

              new Person
            {
                Id = 1,
                FirstName = "Karl",
                LastName = "Someone",
                Age = 18,
                Occupation = "Student",
                HomeAddress = new Address
                {
                    AddressLine1 = "4 Gross st",
                    PostalCode = "25 BA 1",
                    Province = "Berlin",
                    City = "Brandenburg",
                    Country = new Country()
                    {
                        Id = 2,
                        Code = "DE",
                        Name = "Germany"
                    }
                }

            },
            };
        }

    }
}
