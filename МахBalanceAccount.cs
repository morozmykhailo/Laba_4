using System;
using System.Collections.Generic;
using System.Linq;

namespace Net_Lab4
{
   
    public struct MaxBalanceAccount
    {
        public double Balance { get; set; }
        public DateTime Date { get; set; }
    }

    public class AccountAnalysis
    {
        public static Dictionary<string, MaxBalanceAccount> GetMaxBalance(List<FinancialAccount> accounts)
        {
            var maxDepositAccount = new MaxBalanceAccount { Balance = 0, Date = DateTime.MinValue };
            var maxCreditAccount = new MaxBalanceAccount { Balance = 0, Date = DateTime.MinValue };

            foreach (var account in accounts)
            {
                if (account is DepositAccount)
                {
                    if (account.Balance > maxDepositAccount.Balance)
                    {
                        maxDepositAccount.Balance = account.Balance;
                        maxDepositAccount.Date = account.DateStart;
                    }
                }
                else if (account is CreditAccount)
                {
                    if (account.Balance > maxCreditAccount.Balance)
                    {
                        maxCreditAccount.Balance = account.Balance;
                        maxCreditAccount.Date = account.DateStart;
                    }
                }
            }

            var maxAccounts = new Dictionary<string, MaxBalanceAccount>();
            maxAccounts.Add("DepositAccount", maxDepositAccount);
            maxAccounts.Add("CreditAccount", maxCreditAccount);

            return maxAccounts;
        }
    }
}
