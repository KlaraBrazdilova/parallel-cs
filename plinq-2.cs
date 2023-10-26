using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    static void Main(string[] args)
    {
        // Generování vzorových dat
        List<Person> people = GenerateSampleData(100);

        // Použití PLINQ pro paralelní zpracování dat
        var result = people
            .AsParallel()
            .Select(person =>
            {
                // Zde můžete provést různá zpracování dat, například výpočty nebo transformace
                string fullName = $"{person.FirstName} {person.LastName}";
                return new { FullName = fullName, person.Age };
            })
            .ToList(); // Převedení zpět na seznam

        // Výpis výsledků
        foreach (var item in result)
        {
            Console.WriteLine($"Full Name: {item.FullName}, Age: {item.Age}");
        }
      
        Console.WriteLine("--------------------");
        var result2 = result.AsParallel().Where(person => person.Age > 30);
        foreach (var item in result2)
        {
            Console.WriteLine($"Full Name: {item.FullName}, Age: {item.Age}");
        }
    }

    // Generování vzorových dat
    static List<Person> GenerateSampleData(int count)
    {
        var random = new Random();
        var firstNames = new[] { "Alice", "Bob", "Charlie", "David", "Eve" };
        var lastNames = new[] { "Smith", "Johnson", "Brown", "Lee", "Davis" };

        var people = new List<Person>();

        for (int i = 0; i < count; i++)
        {
            var person = new Person
            {
                FirstName = firstNames[random.Next(firstNames.Length)],
                LastName = lastNames[random.Next(lastNames.Length)],
                Age = random.Next(18, 70)
            };

            people.Add(person);
        }

        return people;
    }
}
