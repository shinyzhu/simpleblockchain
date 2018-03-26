using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlockchainApp
{
    public class Blockchain : IEnumerable<Block>
    {
        public List<Block> Chain { get; private set; }

        public int Difficulty { get; set; }

        public List<Transaction> PendingTransactions { get; private set; }

        public double MineReward { get; set; }
    
        public Blockchain(int difficulty = 2, double mineReward = 100.0)
        {
            this.Chain = new List<Block>();
            this.PendingTransactions = new List<Transaction>();

            this.Chain.Add(CreateGenesisBlock());

            this.Difficulty = difficulty;
            this.MineReward = mineReward;
        }

        private Block CreateGenesisBlock()
        {
            return new Block(DateTime.Parse("2018-03-24 14:14:14"), new List<Transaction>());
        }

        public void CreateTransaction(Transaction transaction)
        {
            this.PendingTransactions.Add(transaction);
        }

        public void MinePendingTransactions(string mineRewardAddress)
        {
            var block = new Block(DateTime.Now, this.PendingTransactions);
            block.MineBlock(this.Difficulty);

            System.Console.WriteLine($"Block successfully mined: {block.Hash}");

            this.Chain.Add(block);

            this.PendingTransactions = new List<Transaction>(){
                new Transaction(null, mineRewardAddress, this.MineReward)
            };
        }

        public double GetBalanceOfAddress(string address)
        {
            var balance = 0.0;

            foreach (var block in this.Chain)
            {
                foreach (var transaction in block.Transactions)
                {
                    if(transaction.FromAddress == address)
                    {
                        balance -= transaction.Amount;
                    }

                    if(transaction.ToAddress == address)
                    {
                        balance += transaction.Amount;
                    }
                }
            }

            return balance;
        }

        public bool IsChainValid()
        {
            for (int i = 1; i < this.Chain.Count; i++)
            {
                var currentBlock = this.Chain[i];
                var previousBlock = this.Chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }

            return true;
        }

        public IEnumerator<Block> GetEnumerator()
        {
            return this.Chain.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}