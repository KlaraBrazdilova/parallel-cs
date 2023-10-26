
class Program
{
    static async Task Main()
    {
        string filePath = "example3.txt";

        try
        {
            await CreateExampleFile(filePath);
            var content = ReadFileAsync(filePath);

            Console.WriteLine("File content: " + await content);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        //Console.ReadKey()
    }

    static async Task<string> ReadFileAsync(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            Console.WriteLine("Snazim se cist soubor");
            return await reader.ReadToEndAsync();
        }
    }

    static async Task<bool> CreateExampleFile(string filePath)
    {
        await Task.Delay(3000);
        using var writer = new StreamWriter(filePath);
        await writer.WriteLineAsync("Ahoj toto je example soubor");
        Console.WriteLine("Vytvoril jsem soubor");
        return true;
    }
}
