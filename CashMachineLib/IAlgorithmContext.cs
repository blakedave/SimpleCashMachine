using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CashMachineLib
{
    public interface IAlgorithmContext
    {
        CultureInfo Culture { get; }

        Type CurrentAlgorithmType { get; }

        void Switch<T>() where T : IAlgorithm;

        IAlgorithmOutput Withdraw(double amount);

        double Balance { get; }
    }
}
