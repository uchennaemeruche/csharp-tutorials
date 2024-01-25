using System;
namespace EBank
{
	public class InterestEarningAccount: BankAccount
	{
		public InterestEarningAccount(string name, decimal initialBalance):base(name, initialBalance)
		{


		}

        public override void PerformMonthEndTransactions()
        {
            if(Balance > 500m)
            {
                decimal interest = Balance * 0.2m;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
            //base.PerformMonthEndTransactions();
        }
    }
}

