using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var transaction = new Transaction();
            transaction.TransactionComplete += AfterComplete;
            transaction.StartTransaction(true);
        }

        private static void AfterComplete(object sender, string e)
        {
            Console.WriteLine($"Completed with message: {e}");
        }
    }

    public class Transaction
    {
        public event EventHandler<string> TransactionComplete;

        public void StartTransaction(bool ok)
        {
            //Do something;
            if (ok)
            {
              OnTransactionComplete("All ok");

            }
            else
            {
              OnTransactionComplete("Something failed");

            }

        }

        protected virtual void OnTransactionComplete(string message)
        {
            TransactionComplete?.Invoke(this, message);
        }
    }
}
