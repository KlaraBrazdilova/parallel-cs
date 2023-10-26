using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Vytvoření instance TaskFactory
        TaskFactory<int> taskFactory = new TaskFactory<int>();

        // Vytvoření úkolů pomocí TaskFactory
        Task<int> task1 = taskFactory.StartNew(() => CalculateSum(5, 10));
        Task<int> task2 = taskFactory.StartNew(() => CalculateProduct(3, 4));

        // Další úkoly mohou běžet současně s hlavním úkolem
        Console.WriteLine("Hlavní úkol pracuje...");

        // Čekání na dokončení úkolů
        int result1 = await task1;
        int result2 = await task2;


        Console.WriteLine($"Součet: {result1}");
        Console.WriteLine($"Součin: {result2}");
    }

    static int CalculateSum(int a, int b)
    {
        Console.WriteLine("Výpočet součtu...");
        Task.Delay(2000).Wait(); // Simulace zpoždění
        return a + b;
    }

    static int CalculateProduct(int a, int b)
    {
        Console.WriteLine("Výpočet součinu...");
        Task.Delay(3000).Wait(); // Simulace zpoždění
        return a * b;
    }
}
