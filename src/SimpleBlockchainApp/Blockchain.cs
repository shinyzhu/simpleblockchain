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
    
        public Blockchain(int difficulty = 5)
        {
            this.Chain = new List<Block>();

            this.Chain.Add(CreateGenesisBlock());

            this.Difficulty = difficulty;
        }

        private Block CreateGenesisBlock()
        {
            return new Block(0, DateTime.Parse("2018-03-24 14:14:14"), "Demo Genesis Block");
        }

        public Block GetLatestBlock()
        {
            return this.Chain.LastOrDefault();
        }

        public void AddBlock(Block block)
        {
            block.PreviousHash = this.GetLatestBlock()?.Hash;
            block.MineBlock(this.Difficulty);

            this.Chain.Add(block);
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