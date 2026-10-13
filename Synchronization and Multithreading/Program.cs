using System;
using System.Threading;
using BankingSystem;

void RunTest(string title, Action<BankAccount, int> deposit)
{
    BankAccount account = new BankAccount();
    Thread[] threads = new Thread[10];

    for (int i = 0; i < threads.Length; i++)
    {
        threads[i] = new Thread(() =>
        {
            for (int j = 0; j < 10000; j++)
            {
                deposit(account, 1);
            }
        });
    }

    foreach (Thread thread in threads)
    {
        thread.Start();
    }

    foreach (Thread thread in threads)
    {
        thread.Join();
    }

    int actualBalance = account.GetBalance();
    int expectedBalance = 101000;

    Console.WriteLine($"\n--- {title} ---");
    Console.WriteLine($"Actual balance: {actualBalance} AZN");
    Console.WriteLine($"Expected balance: {expectedBalance} AZN");
    Console.WriteLine($"Correct: {actualBalance == expectedBalance}");
}

RunTest("Part 1: Race Condition",
    (account, amount) => account.Deposit(amount));

RunTest("Part 2: lock",
    (account, amount) => account.DepositWithLock(amount));

RunTest("Part 3: Interlocked",
    (account, amount) => account.DepositWithInterlocked(amount));
//**1.Какой баланс должен получиться?**

//Ожидаемый баланс — **101 000 AZN**.

//Расчёт:
//-Начальный баланс: 1 000 AZN.
//- Количество пополнений: 10 × 10 000 = 100 000.
//- Общая сумма пополнений: 100 000 AZN.
//- Итоговый баланс: 1 000 + 100 000 = **101 000 AZN * *.

//* *2.Почему фактический баланс может оказаться меньше ожидаемого?**

//Несколько потоков могут одновременно читать и изменять общий баланс. Из-за этого один поток может перезаписать результат другого потока, и некоторые пополнения будут потеряны. Это называется **Race Condition (состояние гонки)**.

//**3. Почему операция `_balance += amount` не является атомарной?**

//Потому что она логически состоит из нескольких действий:
//1.Прочитать текущее значение `_balance`.
//2. Прибавить к нему `amount`.
//3. Записать результат обратно в `_balance`.

//Другой поток может изменить баланс между этими действиями. В результате одно из пополнений может потеряться. Чтобы предотвратить это, необходимо использовать синхронизацию, например `lock`, или атомарную операцию `Interlocked.Add()`.
