using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CashMachineLib
{
    public class AlgorithmOne : BaseAlgorithm, IAlgorithm
    {
        public AlgorithmOne(CultureInfo culture): base(culture)
        {
         
        }

        public override IAlgorithmOutput Withdraw(double amount)
        {
            if (SufficientFunds(amount))
            {
                var sb = new StringBuilder();

                for (var idx = 0; idx < CashItems.Length; idx++)
                {
                    if (amount >= CashItems[idx])
                    {
                        int noteCount = (int)Math.Floor(amount / CashItems[idx]);
                        if (noteCount <= CashItemTotals[idx])
                        {
                            CashItemTotals[idx] = CashItemTotals[idx] - noteCount;
                            amount -= noteCount * CashItems[idx];
                            amount = Math.Round(amount, 2);
                            if (sb.Length > 0)
                                sb.Append(", ");

                            sb.Append($"{CashItemsDisplay[idx]} x {noteCount}");
                        }
                    }
                }

                return new BaseAlgorithmOutput
                {
                    Balance = Balance,
                    Output = sb.ToString().Trim()
                };
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
