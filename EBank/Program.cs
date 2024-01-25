using EBank;
var account = new BankAccount("Uchenna", 1000000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

var account2 = new BankAccount("Emeruche", 2000000);
Console.WriteLine($"Account {account2.Number} was created for {account2.Owner} with {account2.Balance} initial balance.");

account2.MakeWithdrawal(2000000, DateTime.Now, "Service charge");
Console.WriteLine($"Account {account2.Number} ({account2.Owner}) balance is {account2.Balance} ");


Console.WriteLine(account2.GetAccountHistory());


var giftCard = new GiftCardAccount("Gift Card", 100, 50);

Console.WriteLine(giftCard);
giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransactions();


giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional funds");
Console.WriteLine(giftCard.GetAccountHistory());


var savings = new InterestEarningAccount("Savings Account", 10000);
Console.WriteLine(savings);
savings.MakeDeposit(750, DateTime.Now, "Holiday Funds");
savings.MakeDeposit(1250, DateTime.Now, "House Rent");
savings.MakeWithdrawal(250, DateTime.Now, "Electricity Bills");
savings.PerformMonthEndTransactions();
Console.WriteLine(savings.GetAccountHistory());


var creditAccount = new LineOfCreditAccount("Credit Account", 0, 10000);
Console.WriteLine(creditAccount);
creditAccount.MakeWithdrawal(100m, DateTime.Now, "Salary Advance");
creditAccount.MakeDeposit(50m, DateTime.Now, "Salary Advance deduction repayment");
creditAccount.MakeWithdrawal(5000m, DateTime.Now, "Overdraft for emergencey");
creditAccount.MakeDeposit(150m, DateTime.Now, "Overdraft installment");
creditAccount.PerformMonthEndTransactions();

Console.WriteLine(creditAccount.GetAccountHistory());


