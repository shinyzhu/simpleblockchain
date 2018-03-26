using System;

namespace SimpleBlockchainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Blockchain now starting...");

            var blockchain = new Blockchain();
            blockchain.CreateTransaction(new Transaction("user1", "user2", 100));
            blockchain.CreateTransaction(new Transaction("user2", "user1", 50));

            System.Console.WriteLine("Starting the miner...");
            blockchain.MinePendingTransactions("miner");
            System.Console.WriteLine($"Balance of the miner is {blockchain.GetBalanceOfAddress("miner")}");

            System.Console.WriteLine("Starting the miner...again");
            blockchain.MinePendingTransactions("miner");
            System.Console.WriteLine($"Balance of the miner is {blockchain.GetBalanceOfAddress("miner")}");
        }
    }
}
