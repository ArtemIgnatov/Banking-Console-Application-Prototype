using System;
using System.Collections.Generic;
namespace HW_13

{
    /// <summary>
    /// Модель банковского счета
    /// </summary>
    public class BankAccount
    {
        static List<string> accountNums;

        static BankAccount()
        {
            accountNums = new List<string>();
        }

        /// <summary>
        /// Создание счета
        /// </summary>
        /// <param name="AccountNum"></param>
        /// <param name="AccountBalance"></param>
        public BankAccount(string AccountNum, double AccountBalance)
        {
            if (AccountNum == String.Empty || accountNums.Contains(AccountNum)) { AccountNum = $"{Guid.NewGuid().ToString().Substring(0, 6)}"; }
            this.accountNum = AccountNum;
            accountNums.Add(AccountNum);

            accountBalance = 0.0;
            this.accountBalance = AccountBalance;
        }

        /// <summary>
        /// Создание счета с автопарамерами
        /// </summary>
        public BankAccount() : this("", 0)
        { }

        private string accountNum; // Поле номера счета
        private double accountBalance; // Поле с балансом счета

        /// <summary>
        /// Номер счета
        /// </summary>
        public string AccountNum
        {
            get { return this.accountNum; }
            set { this.accountNum = value; }
        }

        /// <summary>
        /// Баланс счета
        /// </summary>
        public virtual double AccountBalance
        {
            get { return this.accountBalance; }
            set { this.accountBalance = value; }
        }



        /// <summary>
        /// Метод для перевода средств на другой счет
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="accountFrom"></param>
        /// <param name="accountTo"></param>
        /// <param name="value"></param>
        public virtual void MoneyTransfe<T>(T accountTo) where T : BankAccount

        {
            Console.WriteLine($"Введите сумму:");
            double value = Convert.ToDouble(Console.ReadLine());

            if (this.AccountBalance < value)
            {
                Console.WriteLine($"На счете {this.AccountBalance} недостаточно средств. \nПожалуйста, пополните счет.");
            }
            else
            {
                this.AccountBalance -= value;
                accountTo.AccountBalance += value;
                Console.WriteLine($"Перевод выполнен!");  
            }

        }

        /// <summary>
        /// Метод для пополнения счета с помощью кеша
        /// </summary>
        /// <param name="value"></param>
        public virtual void CashRefill()
        {
            Console.WriteLine($"Введите сумму:");
            double value = Convert.ToDouble(Console.ReadLine());
            this.accountBalance += value;
            Console.WriteLine($"Счет {this.accountNum} успешо пополнен на сумму {value}");
       
        }

         /// <summary>
        /// Метод для вывода информации о счете
        /// </summary>
        /// <returns></returns>
        public virtual string AccountInformation()
        {
            return String.Format("Account num:{0,-10} Balance: {1,-15}",
                this.accountNum,
                this.accountBalance);
        }
    }

    /// <summary>
    /// Недепозитный счет
    /// </summary>
    public class NotDepositeAccount : BankAccount
    {

        /// <summary>
        /// Создание счета
        /// </summary>
        /// <param name="AccountNum"></param>
        /// <param name="AccountBalance"></param>
        public NotDepositeAccount(string AccountNum, double AccountBalance) : base(AccountNum, AccountBalance) { }

        /// <summary>
        /// Создание счета с автопарамерами
        /// </summary>
        public NotDepositeAccount() : this("", 0)
        { }

    }
}
