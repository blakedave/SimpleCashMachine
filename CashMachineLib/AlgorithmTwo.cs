using System;
using System.Globalization;
using System.Text;

namespace CashMachineLib
{
    public class AlgorithmTwo : BaseAlgorithm, IAlgorithm
    {
        private const double CASH_ITEM = 20.00;
        public AlgorithmTwo(CultureInfo culture): base(culture)
        {

        }

        public override IAlgorithmOutput Withdraw(double amount)
        {
            if (SufficientFunds(amount))
            {
                int idx = Array.IndexOf(CashItems, CASH_ITEM);

                if (amount >= CashItems[idx])
                {
                    int noteCount = (int)Math.Floor(amount / CashItems[idx]);
                    if (noteCount > CashItemTotals[idx])
                    {
                        noteCount = CashItemTotals[idx];
                    }

                    CashItemTotals[idx] = CashItemTotals[idx] - noteCount;

                    return new BaseAlgorithmOutput
                    {
                        Balance = Balance,
                        Output = $"{CashItemsDisplay[idx]} x {noteCount}"
                    };
                }
                else
                {
                    return new BaseAlgorithmOutput
                    {
                        Output = $"Amount must be greater than {CASH_ITEM.ToString("C", Culture)}"
                    };
                }
                
            }
            else
            {
                return new BaseAlgorithmOutput
                {
                    Balance = Balance,
                    Output = "Insufficient funds!"
                };
            }
        }
    }
}