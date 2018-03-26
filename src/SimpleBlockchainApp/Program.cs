using System;

namespace SimpleBlockchainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Blockchain now starting...");

            var blockchain = new Blockchain();
            Console.WriteLine("Mining block #1...");
            blockchain.AddBlock(new Block(1, DateTime.Now, new{ User = "Demo User", Amount = 4.0 }));
            Console.WriteLine("Mining block #2...");
            blockchain.AddBlock(new Block(2, DateTime.Now, new{ User = "Demo User 2", Amount = 8.0 }));
        }
    }
}
