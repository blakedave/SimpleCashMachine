using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

                var orderedFloat = Float.OrderByDescending( o => o.Value).ToArray();

                var sb = new StringBuilder();

                Array.ForEach(orderedFloat, item => 
                {
                    if (amount >= item.Value)
                    {
                        int noteCount = (int)Math.Floor(amount / item.Value);
                        if (noteCount <= item.Total)
                        {
                            item.Total -= noteCount;
                            amount -= noteCount * item.Value;
                            amount = Math.Round(amount, 2);
                            if (sb.Length > 0)
                                sb.Append(", ");

                            sb.Append($"{item.Display} x {noteCount}");
                        }
                    }
                });

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
