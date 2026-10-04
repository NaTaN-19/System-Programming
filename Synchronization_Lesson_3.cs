ManualResetEvent manualResetEvent = new ManualResetEvent(false);

Thread waitingThread = new Thread(() =>
{
    manualResetEvent.WaitOne();

    Console.WriteLine("All orders have been processed!");
});
Semaphore semaphore = new Semaphore(2, 2);
int SharedProcessedOrder = 0;
Thread thread1 = new Thread(() =>
{
    for (int i = 0; i < 100; i++)
    {
        semaphore.WaitOne();

        try
        {
            Console.WriteLine($"Process Order {i} ");
            Interlocked.Increment(ref SharedProcessedOrder);
        }
        finally
        {
            semaphore.Release();
        }

    }
});
Thread thread2 = new Thread(() =>
{
    for (int i = 0; i < 100; i++)
    {
        semaphore.WaitOne();

        try
        {
            Console.WriteLine($"Process Order {i} ");
            Interlocked.Increment(ref SharedProcessedOrder);
        }
        finally
        {
            semaphore.Release();
        }
    }
});
Thread thread3 = new Thread(() =>
{
    for (int i = 0; i < 100; i++)
    {
        semaphore.WaitOne();

        try
        {
            Console.WriteLine($"Process Order {i} ");
            Interlocked.Increment(ref SharedProcessedOrder);
        }
        finally
        {
            semaphore.Release();
        }
    }
});
Thread thread4 = new Thread(() =>
{
    for (int i = 0; i < 100; i++)
    {
        semaphore.WaitOne();

        try
        {
            Console.WriteLine($"Process Order {i} ");
            Interlocked.Increment(ref SharedProcessedOrder);
        }
        finally
        {
            semaphore.Release();
        }
    }
});
Thread thread5 = new Thread(() =>
{
    for (int i = 0; i < 100; i++)
    {
        semaphore.WaitOne();

        try
        {
            Console.WriteLine($"Process Order {i} ");
            Interlocked.Increment(ref SharedProcessedOrder);
        }
        finally
        {
            semaphore.Release();
        }
    }
});
waitingThread.Start();

thread1.Start();
thread2.Start();
thread3.Start();
thread4.Start();
thread5.Start();

thread1.Join();
thread2.Join();
thread3.Join();
thread4.Join();
thread5.Join();

Console.WriteLine(SharedProcessedOrder);

manualResetEvent.Set();

waitingThread.Join();
