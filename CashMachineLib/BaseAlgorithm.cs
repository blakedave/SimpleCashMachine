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

            Float = new CashItem[]
            { 
                new CashItem { Value=20.00, Display="£20", Total=50 },
                new CashItem { Value=50.00, Display="£50", Total=50 },
                new CashItem { Value=10.00, Display="£10", Total=50 },
                new CashItem { Value=5.00, Display="£5", Total=50 },
                new CashItem { Value=2.00, Display="£2", Total=100 },
                new CashItem { Value=1.00, Display="£1", Total=100 },
                new CashItem { Value=0.50, Display="50p", Total=100 },
                new CashItem { Value=0.20, Display="20p", Total=100 },
                new CashItem { Value=0.10, Display="10p", Total=100 },
                new CashItem { Value=0.05, Display="5p", Total=100 },
                new CashItem { Value=0.02, Display="2p", Total=100 },
                new CashItem { Value=0.01, Display="1p", Total=100 }
            };
        }

        protected CashItem[] Float { get; private set; }

        protected double[] CashItems { get; set; }
        
        protected int[] CashItemTotals { get; set; }

        protected string[] CashItemsDisplay { get; set; }

        public virtual double Balance
        {
            get
            {
                double bal = 0.00;

                for (int i = 0; i < Float.Length; i++)
                {
                    bal += Float[i].Total * Float[i].Value;
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
