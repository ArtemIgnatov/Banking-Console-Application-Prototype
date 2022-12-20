using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
namespace HW_13
{
    public class DepositeAccount : BankAccount
    {
        //private static Timer aTimer;
        //private static int count;

        static DepositeAccount()
        {
            //count = 0;
            //aTimer = new Timer();
            //aTimer.Interval = 1000 * 60; // Условный месяц вклада
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            ////aTimer.Elapsed += OnTimedEvent;
            //aTimer.AutoReset = true;

            //// Start the timer
            //aTimer.Enabled = true;

        }

        /// <summary>
        /// Создание депозитного счета 
        /// </summary>
        /// <param name="AccountNum"></param>
        /// <param name="AccountBalance"></param>
        /// <param name="Term"></param>
        public DepositeAccount(string AccountNum, double AccountBalance, int Term) : base(AccountNum, AccountBalance)
        {
            term = Term; // Колличество месяцев согласно вкладу
            //interestRate = InterestRate;

            if (Term < 6) InterestRate = 0.12; // Ставка по вкладу до полугода
            else InterestRate = 0.24; // Ставка по вкладу свыше полугода

        }

        public DepositeAccount() : this("", 0, 0)
        { }

        /// <summary>
        /// Метод по выводу информации о счете
        /// </summary>
        /// <returns></returns>
        public override string AccountInformation()
        {
            if (this.Term == 0 || this.AccountBalance == 0) return String.Format("Счет не открывался");
            else
            {
                return String.Format("Account num:{0,-10} Balance: {1,-15} Rate: {2, -3} %  / Term: {3, -3}мес. ",
                this.AccountNum,
                this.AccountBalance,
                this.InterestRate,
                this.Term
                );
            }

        }

        private int term; // Поле колличества месяцев на вкладе
        private double InterestRate; // Размер процентной ставки


        /// <summary>
        /// Срок вклада в месяцах
        /// </summary>
        public int Term
        {
            get { return this.term; }
            set { term = value; }
        }

        ///// <summary>
        ///// Обновление баланса согласно таймеру
        ///// </summary>
        //public void BalanceUpdateByTime()
        //{
        //    this.AccountBalance += this.AccountBalance * (InterestRate / this.Term);
        //    count++;
        //    if (count == this.Term) aTimer.Enabled = false;
        //}


        //public static void OnTimedEvent(Object source, ElapsedEventArgs e)
        //{

        //    BalanceUpdateByTime();
        //}
    }
}
