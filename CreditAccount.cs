using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;
namespace Net_Lab4
{
    public class CreditAccount : FinancialAccount
    {
        public double CreditLimit;
        public CreditAccount(double balance, string currency, double credit_limit) : base(balance, currency)
        {
            this.CreditLimit = credit_limit;
        }

        public override string DepMoney(double amount)
        {
            var protocol = new StringBuilder();
            if (amount > 0)
            {
                Balance += amount;
                protocol.AppendLine($"Рахунок попвнено: {amount}. Поточний баланс: {Balance}");
            }
            else protocol.AppendLine($"Cума поповнення має бути додатньою.");
            return protocol.ToString();
        }

        public override string GetMoney(double amount)
        {
            var protocol = new StringBuilder();
            if (amount > 0 && Balance - amount >= -CreditLimit)
            {
                Balance -= amount;
                protocol.AppendLine($"Знято: {amount} {CurrencyType}. Поточний баланс: {Balance}");
            }
            else protocol.AppendLine($"Сума зняття не може перевищувати балансу.");
            return protocol.ToString();
        }

        public string CountRepaySum(double interRate, double repay)
        {
            var protocol = new StringBuilder();
            repay = repay + repay * interRate / 100;
            protocol.AppendLine($"Сума для погашення: {repay} {CurrencyType}");
            return protocol.ToString();
        }
    }
}
