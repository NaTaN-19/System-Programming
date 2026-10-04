async Task ProcessOrderAsync(int orderId)
{
    Console.WriteLine($"Order {orderId} is processing...");
    await Task.Delay(2000);
    Console.WriteLine($"Order {orderId} processing is completed...");
}

await Task.WhenAll
    (
    ProcessOrderAsync(1),
    ProcessOrderAsync(2),
    ProcessOrderAsync(3)
    );

int counter = 0;


Task task1 = Task.Run(() =>
{
    for (int i = 0; i < 1000; i++)
    {
        Interlocked.Increment(ref counter);
    }
});
Task task2 = Task.Run(() =>
{
    for (int i = 0; i < 1000; i++)
    {
        Interlocked.Increment(ref counter);
    }
});
Task task3 = Task.Run(() =>
{
    for (int i = 0; i < 1000; i++)
    {
        Interlocked.Increment(ref counter);
    }
});
Task task4 = Task.Run(() =>
{
    for (int i = 0; i < 1000; i++)
    {
        Interlocked.Increment(ref counter);
    }
});
Task task5 = Task.Run(() =>
{
    for (int i = 0; i < 1000; i++)
    {
        Interlocked.Increment(ref counter);
    }
});
await Task.WhenAll(task1, task2, task3, task4, task5);
Console.WriteLine(counter);
