
namespace Net_Lab4
{
    public abstract class FinancialAccount
    {
        public double Balance;
        public DateTime DateStart;
        public string CurrencyType;

        public FinancialAccount(double balance, string currency)
        {
            if (balance >= 0) this.Balance = balance;
            else throw new ArgumentException("Уведіть коректне значення.");

            this.DateStart = DateTime.Now;

            if (currency != null && currency != "") this.CurrencyType = currency;
            else throw new ArgumentException("Уведіть коректне значення.");
        }
        
        public abstract string GetMoney(double amount);
        public abstract string DepMoney(double amount);

    }

}
