﻿namespace ParallelProgrammingCsharp;

class Program
{
    public class BankAccount
    {
        public object padLock = new();
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            lock (padLock)
            {
                Balance += amount;
            }
        }

        public void Withdraw(int amount)
        {
            lock (padLock)
            {
                Balance -= amount;
            }
        }
    }

    static void Main(string[] args)
    {
        var bankAccount = new BankAccount();
        var taskList = new List<Task>();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                var task = Task.Factory.StartNew(() => bankAccount.Deposit(100));
                taskList.Add(task);
            }

            for (int j = 0; j < 1000; j++)
            {
                var task = Task.Factory.StartNew(() => bankAccount.Withdraw(100));
                taskList.Add(task);
            }
        }

        Task.WaitAll(taskList.ToArray());

        Console.WriteLine($"Balance: {bankAccount.Balance}");
    }
}