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

        private static void AfterComplete(object sender, TransactionEventArgs e)
        {
            Console.WriteLine($"Completed {e.Ok} with message: {e.Message}");
        }
    }

    public class Transaction
    {
        public event EventHandler<TransactionEventArgs> TransactionComplete;

        public void StartTransaction(bool ok)
        {
            //Do something;
            if (ok)
            {
              OnTransactionComplete("All ok", true);

            }
            else
            {
              OnTransactionComplete("Something failed", false);

            }

        }

        protected virtual void OnTransactionComplete(string message, bool ok)
        {
            var eventArgs = new TransactionEventArgs
            {
                Message = message,
                Ok = ok
            };

            TransactionComplete?.Invoke(this, eventArgs);
        }
    }

    public class TransactionEventArgs : EventArgs
    {
        public string Message { get; set; }
        public bool Ok { get; set; }

    }
}
