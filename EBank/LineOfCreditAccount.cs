using System;
namespace EBank
{
	public class LineOfCreditAccount:BankAccount
	{
        protected decimal _OverdranWithdrawalFee = 20;
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

        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        => isOverdrawn ? new Transaction(-_OverdranWithdrawalFee, DateTime.Now, "Apply overdraft fee") : default;
    }
}

