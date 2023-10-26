using System;
using System.Threading;

class Program
{
    private static readonly object lockObject = new object();
    static Mutex mutex = new Mutex();
    static Semaphore semaphore = new Semaphore(2, 2);

    static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            Thread thread = new Thread(() => DoWork2(i));
            thread.Start();
        }
    }

    static void DoWork(int i)
    {
        lock (lockObject)
        {
            // Kritická sekce - pouze jedno vlákno má přístup k tomuto kódu najednou.
            Console.WriteLine("Vlákno začalo pracovat." + i);
            Thread.Sleep(1000);
            Console.WriteLine("Vlákno skončilo práci." + i);
        }
    }
    static void DoWork2(int i)
    {
        mutex.WaitOne(); // Vstoupit do kritické sekce
        try
        {
            // Kritická sekce - pouze jedno vlákno má přístup k tomuto kódu najednou.
            Console.WriteLine("Vlákno začalo pracovat." + i);
            Thread.Sleep(1000);
            Console.WriteLine("Vlákno skončilo práci." + i);
        }
        finally
        {
            mutex.ReleaseMutex(); // Odejít z kritické sekce
        }
    }
    static void DoWork3(int i)
    {
        semaphore.WaitOne(); // Pokusit se vstoupit do kritické sekce
        try
        {
            // Kritická sekce - pouze 2 vlákna mohou vstoupit současně.
            Console.WriteLine("Vlákno začalo pracovat." + i);
            Thread.Sleep(1000);
            Console.WriteLine("Vlákno skončilo práci." + i);
        }
        finally
        {
            semaphore.Release(); // Odejít z kritické sekce
        }
    }


    //static ReaderWriterLock rwl = new ReaderWriterLock();
    //static int sharedData = 0;

    //static void Main()
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        Thread readerThread = new Thread(ReadData);
    //        readerThread.Start();
    //    }

    //    for (int i = 0; i < 2; i++)
    //    {
    //        Thread writerThread = new Thread(WriteData);
    //        writerThread.Start();
    //    }
    //}

    //static void ReadData()
    //{
    //    rwl.AcquireReaderLock(Timeout.Infinite);
    //    try
    //    {
    //        Console.WriteLine("Čtení dat: " + sharedData);
    //    }
    //    finally
    //    {
    //        rwl.ReleaseReaderLock();
    //    }
    //}

    //static void WriteData()
    //{
    //    rwl.AcquireWriterLock(Timeout.Infinite);
    //    try
    //    {
    //        sharedData++;
    //        Console.WriteLine("Zápis dat: " + sharedData);
    //    }
    //    finally
    //    {
    //        rwl.ReleaseWriterLock();
    //    }
    //}
}

