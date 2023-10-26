class Program
{
    static async Task Main()
    {
        // Vytvoření úkolu
        Task<int> task = Task.Run(() => CalculateSum(5, 10));

        // Další úkoly mohou běžet současně s hlavním úkolem
        Console.WriteLine("Hlavní úkol pracuje...");

        // Očekávání a získání výsledku z vedlejšího úkolu
        //int result = await task;
        int result = task.Result;

        Console.WriteLine($"Výsledek: {result}");
    }

    static int CalculateSum(int a, int b)
    {
        Console.WriteLine("Vedlejší úkol provádí výpočet...");
        Task.Delay(2000).Wait(); // Simulace zpoždění
        return a + b;
    }
}

