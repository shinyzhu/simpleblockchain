using System;

namespace SimpleBlockchainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Blockchain now starting...");

            var blockchain = new Blockchain();
            blockchain.AddBlock(new Block(1, DateTime.Now, new{ User = "Demo User", Amount = 4.0 }));
            blockchain.AddBlock(new Block(2, DateTime.Now, new{ User = "Demo User 2", Amount = 8.0 }));

            Console.WriteLine($"Blockchain is valid? {blockchain.IsChainValid()}");

            Console.WriteLine("Changing data in blockchain.");
            blockchain.Chain[1].Data = new { User = "Middle Man", Amount = 16.0};
            
            Console.WriteLine($"Blockchain now is valid? {blockchain.IsChainValid()}");
        }
    }
}
