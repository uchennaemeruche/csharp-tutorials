using System;
using System.Text;

namespace EBank
{
	public class BankAccount
	{
		

		private static int s_accountNumberSeed = 1234567890;
		public string Number { get; }
		public string Owner { get; set; }

        public decimal Balance {
			get {
				decimal balance = 0;
				foreach(var item in _transactions)
				{
					balance += item.Amount;
				}
				return balance;
			}
		}

		public virtual void PerformMonthEndTransactions() { }

        private readonly decimal _minimumBalance;

		public BankAccount(string name, decimal initialBalance): this(name, initialBalance, 0) { }

        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
		{
			this.Number = s_accountNumberSeed.ToString();
			s_accountNumberSeed++;

			this.Owner = name;
			_minimumBalance = minimumBalance;
			if(initialBalance > 0)
				this.MakeDeposit(initialBalance, DateTime.Now, "Opening balance");
		}

		List<Transaction> _transactions = new List<Transaction>();

		public void MakeDeposit(decimal amount, DateTime date, string description) {
			if(amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount can not be less than or eqaul to 0");
			}

			var deposit = new Transaction(amount, date, description);
			_transactions.Add(deposit);
		}

		public void MakeWithdrawal(decimal amount, DateTime date, string description) {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount can not be less than or eqaul to 0");
            }

			Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);

			Transaction? withdrawal = new(-amount, date, description);
			_transactions.Add(withdrawal);
			if (overdraftTransaction != null)
				_transactions.Add(overdraftTransaction);

			
        }

		protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn) {
			if (isOverdrawn)
			{
				throw new InvalidOperationException("Insufficient amount - Withdrawal limit exceeded");
			}
			else
			{
				return default;
			}
		}

		public string GetAccountHistory()
		{
			var report = new StringBuilder();

			decimal balance = 0;

			report.AppendLine("Date\t\t Amount\t\t Balance\t Description");
			foreach(var transaction in _transactions)
			{
				balance += transaction.Amount;
				report.AppendLine($"{transaction.Date.ToShortDateString()}\t {transaction.Amount}\t {balance}\t {transaction.Description}");
			}

			return report.ToString();
		}
    }
}

