using CashMachineLib;
using System;
using System.Globalization;

namespace CashMachineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");

            AlgorithmContext context = new AlgorithmContext(culture);
            
            context.Switch<AlgorithmOne>();
            //context.Switch<AlgorithmTwo>();

            while (true)
            {
                MakeAWithdrawl(context);

                Console.WriteLine();
                Console.Write("Another withdrawal? (Y/N): ");
                var info = Console.ReadKey();
                if (info.Key == ConsoleKey.N)
                    break;

                Console.Clear();
            }
        }

        static void MakeAWithdrawl(AlgorithmContext context)
        {
            Console.WriteLine("Enter amount: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out var amount))
            {
                Console.WriteLine();
                Console.WriteLine("Opening Balance");
                Console.WriteLine(context.Balance.ToString("C", context.Culture));

                Console.WriteLine();

                IAlgorithmOutput output = context.Withdraw(amount);

                Console.WriteLine("Input");
                Console.WriteLine(amount.ToString("C", context.Culture));
                Console.WriteLine("Output");
                Console.WriteLine(output.Output);
                Console.WriteLine("Balance");
                Console.WriteLine(context.Balance.ToString("C", context.Culture));
            }
            else
            {
                Console.WriteLine("Couldn't parse input...");
            }
        }
    }
}
