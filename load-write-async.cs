using System.Text;

static async Task<string> loadAsync(string path)
{
    try
    {
        var fileContent = await ReadFileAsync(path);
        Console.WriteLine("File content: " + fileContent);
        return fileContent;
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("File not found.");
        return null;
    }
}

static async Task<string> ReadFileAsync(string filePath)
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        return await reader.ReadLineAsync();
    }
}

static async Task writeAsync(string path, string content)
{
    try
    {
        await Task.Delay(1000);
        await WriteFileAsync(path, content);
        Console.WriteLine("File saved successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error saving the file: " + ex.Message);
    }
}

static async Task WriteFileAsync(string path, string content)
{
    using (var writer = new StreamWriter(path, false, Encoding.UTF8))
    {
        await writer.WriteAsync(content);
    }
}



String content = "Ahoj, toto je paralelní text 3";
await writeAsync("pokus3.txt", content);
Task<String> newText = loadAsync("pokus3.txt");
Console.WriteLine(newText);
