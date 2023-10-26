
//paralelní for
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

Parallel.For(0, numbers.Length, i =>
{
    Console.WriteLine($"Processed {numbers[i]} on Thread {Thread.CurrentThread.ManagedThreadId}");
});

Console.WriteLine("Parallel.For loop completed.");


//paralelní foreach
List<string> fruits = new List<string> { "Apple", "Banana", "Cherry", "Date", "Fig" };

Parallel.ForEach(fruits, fruit =>
{
    Console.WriteLine($"Processed {fruit} on Thread {Thread.CurrentThread.ManagedThreadId}");
});

Console.WriteLine("Parallel.ForEach loop completed.");


//paralelní volání metod
Parallel.Invoke(
            () => PrintMessage("Message 1"),
            () => PrintMessage("Message 2"),
            () => PrintMessage("Message 3")
        );

Console.WriteLine("Parallel.Invoke completed.");

static void PrintMessage(string message)
{
    Console.WriteLine(message);
}
