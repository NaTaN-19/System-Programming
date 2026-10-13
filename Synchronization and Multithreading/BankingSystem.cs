using System.Threading;
namespace BankingSystem
{
    public class BankAccount
    {
        private int _balance = 1000;
        private readonly object _lock = new object();

        // Часть 1: Race Condition
        public void Deposit(int amount)
        {
            _balance += amount;
        }

        // Часть 2: Синхронизация через lock
        public void DepositWithLock(int amount)
        {
            lock (_lock)
            {
                _balance += amount;
            }
        }

        // Часть 3: Синхронизация через Interlocked
        public void DepositWithInterlocked(int amount)
        {
            Interlocked.Add(ref _balance, amount);
        }

        // Получение текущего баланса
        public int GetBalance()
        {
            return _balance;
        }
    }
}
