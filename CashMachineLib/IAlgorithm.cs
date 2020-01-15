using System;
using System.Collections.Generic;
using System.Text;

namespace CashMachineLib
{
    public interface IAlgorithm
    {
        IAlgorithmOutput Withdraw(double amount);
        
        double Balance { get;  }

    }
}
