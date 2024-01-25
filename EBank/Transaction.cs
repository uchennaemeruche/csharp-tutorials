using System;
namespace EBank
{
	public class Transaction
	{
		public decimal Amount { get; }
		public DateTime Date { get; }
		public string Description { get; }


		public Transaction(decimal amount, DateTime date, string description)
		{
			this.Amount = amount;
			this.Date = date;
			this.Description = description;
		}
	}
}

