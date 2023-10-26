// See https://aka.ms/new-console-template for more informati

public static class Globals
{
    public static int COUNTER = 0;
    public static int COUNTOFTHREADS = 100;
}

class Program
{
    public static void AddInThread(object id)
    {
        Thread thread = Thread.CurrentThread;
        int localCounter = Globals.COUNTER;
        Console.WriteLine("Píše vlákno: " + thread.ManagedThreadId);
        //Thread.Sleep(10);
        localCounter++;
        //Thread.Sleep(10);
        Globals.COUNTER = localCounter;
        Console.WriteLine("ZAPSÁNO vlákno: " + thread.ManagedThreadId);
    }
    public static void Main()
    {
        for (int i = 0; i < 100; i++)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(AddInThread));
        }
        Console.Read();
        Console.WriteLine(Globals.COUNTER);
    }
}
