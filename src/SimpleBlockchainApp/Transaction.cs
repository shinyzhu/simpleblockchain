using System;

namespace SimpleBlockchainApp
{
    public class Transaction
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public double Amount { get; set; }

        public Transaction(string fromAddress, string toAddress, double amount)
        {
            this.FromAddress = fromAddress;
            this.ToAddress = toAddress;
            this.Amount = amount;
        }
    }
}