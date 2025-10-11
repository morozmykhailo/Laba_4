using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace Net_Lab4
{
    public class DepositAccount : FinancialAccount
    {
        public double InterestRate;
        public DepositAccount(double balance, string currency, double interest_rate): base(balance, currency)
        {
            this.InterestRate = interest_rate;
        }

        public override string DepMoney(double amount)
        {
            var protocol = new StringBuilder();
            if (amount > 0)
            {
                Balance += amount;
                protocol.AppendLine($"Рахунок попвнено: {amount}. Поточний баланс: {Balance}");
            }
            else protocol.AppendLine($"Сума поповнення має бути додатньою");
            return protocol.ToString();
        }

        public override string GetMoney(double amount)
        {
            var protocol = new StringBuilder();

            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                protocol.AppendLine($"Знято: {amount} {CurrencyType}. Поточний баланс: {Balance}");
            }
            else protocol.AppendLine($"Сума зняття не може перевищувати балансу.");
            return protocol.ToString();
        }

        public string CalculateInterestRate(int m)
        {
            var protocol = new StringBuilder();

            double interest_rate = Balance * (InterestRate / 100) *( m / 12);
            protocol.AppendLine($"Відсотків за {m} місяць(-ів): {interest_rate} {CurrencyType}");
            return protocol.ToString();
        }
    }
}
