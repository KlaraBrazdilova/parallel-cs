// See https://aka.ms/new-console-template for more informati

public static class Globals
{
    public static int COUNTER = 0;
    public static int COUNTOFTHREADS = 100;
}

class Program{
    static void AddInThread(int id)
    {
        int localCounter = Globals.COUNTER;
        //Console.WriteLine("Píše vlákno: " + id);
        Thread.Sleep(10);
        localCounter++;
        Thread.Sleep(10);
        Globals.COUNTER = localCounter;
        //Console.WriteLine("ZAPSÁNO vlákno: " + id);
    }
    public static void Main()
    {
        for (int j = 0; j < 5; j++)
        {
            Thread[] threads = new Thread[Globals.COUNTOFTHREADS];
            for (int i = 0; i < Globals.COUNTOFTHREADS; i++)
            {
                Thread t = new Thread(() => AddInThread(i));
                threads[i] = t;
                t.Start();
            }
            foreach (Thread t in threads)
            {
                t.Join();
            }
            Console.WriteLine(Globals.COUNTER);
            Globals.COUNTER = 0;
        }
    }
}
