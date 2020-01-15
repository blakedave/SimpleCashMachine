using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CashMachineLib
{
    public abstract class BaseAlgorithm : IAlgorithm
    {
        public BaseAlgorithm()
        {

        }

        public BaseAlgorithm(CultureInfo culture)
        {
            Culture = culture;
            InitFloat();
        }

        public virtual void InitFloat()
        {
            CashItems = new double[] { 50.00, 20.00, 10.00, 5.00, 2.00, 1.00, 0.50, 0.20, 0.10, 0.05, 0.02, 0.01 };
            CashItemsDisplay = new string[] { "£50", "£20", "£10", "£5", "£2", "£1", "50p", "20p", "10p", "5p", "2p", "1p" };
            CashItemTotals = new int[] { 50, 50, 50, 50, 100, 100, 100, 100, 100, 100, 100, 100 };
        }

        protected double[] CashItems { get; set; }
        
        protected int[] CashItemTotals { get; set; }

        protected string[] CashItemsDisplay { get; set; }

        public virtual double Balance
        {
            get
            {
                double bal = 0.00;

                for (int i = 0; i < CashItems.Length; i++)
                {
                    bal += CashItems[i] * CashItemTotals[i];
                }
                return bal;
            }
        }

        public virtual CultureInfo Culture { get; }

        public abstract IAlgorithmOutput Withdraw(double amount);

        protected bool SufficientFunds(double withdrawalAmount)
        {
            return withdrawalAmount <= Balance;
        }
    }
}
