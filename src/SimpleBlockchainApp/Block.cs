using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace SimpleBlockchainApp
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime Timestamp { get; set; }
        public object Data { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public int Nonce { get; set; }

        public Block(int index, DateTime timestamp, object data, string previousHash = "")
        {
            this.Index = index;
            this.Timestamp = timestamp;
            this.Data = data;
            this.PreviousHash=  previousHash;

            this.Hash = CalculateHash();

            this.Nonce = 0;
        }

        public string CalculateHash()
        {
            var alg = SHA256.Create();

            var blockBits = Encoding.UTF8.GetBytes(this.ToString());
            var hashBits = alg.ComputeHash(blockBits);

            var hash = BitConverter.ToString(hashBits).Replace("-", string.Empty);

            return hash;
        }

        public void MineBlock(int difficulty)
        {
            while (this.Hash.Substring(0, difficulty) != 0.ToString($"D{difficulty}"))
            {
                this.Nonce++;
                this.Hash = this.CalculateHash();

                Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")}] Mining: {this.Hash} nonce={this.Nonce}");
            }

            Console.WriteLine($"Block mined: {this.Hash}");
        }

        public override string ToString()
        {
            return $"{this.Index}{this.PreviousHash}{this.Timestamp}{JsonConvert.SerializeObject(this.Data)}{this.Nonce}";
        }
    }
}