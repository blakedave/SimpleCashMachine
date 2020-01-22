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
                var item = Array.Find(Float, item => item.Value == CASH_ITEM);

                if (amount >= item.Value)
                {
                    int noteCount = (int)Math.Floor(amount / item.Value);
                    if (noteCount > item.Total)
                    {
                        noteCount = item.Total;
                    }

                    item.Total -= noteCount;

                    return new BaseAlgorithmOutput
                    {
                        Balance = Balance,
                        Output = $"{item.Display} x {noteCount}"
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