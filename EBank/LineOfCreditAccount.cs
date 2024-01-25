using System;
namespace EBank
{
	public class LineOfCreditAccount:BankAccount
	{
		public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
        {

		}

        public override void PerformMonthEndTransactions()
        {
           if(Balance < 0)
            {
                decimal interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "charge monthly interest");
            }
        }
    }
}

