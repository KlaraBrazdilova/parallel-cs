using System;
using System.Linq;
using System.Threading.Tasks;


// Seznam čísel
var numbers = Enumerable.Range(1, 20);

// PLINQ dotaz na nalezení prvního sudého čísla ve větším seznamu
var result = numbers.AsParallel().FirstOrDefault(x => x % 2 == 0);

Console.WriteLine($"První sudé číslo: {result}");

// PLINQ dotaz na transformaci seznamu a výpočet sumy
var query = numbers.AsParallel()
            .Select(x => x * 2)
            .Where(x => x > 10).ToList();


foreach (var x in query) { Console.WriteLine(x); }



