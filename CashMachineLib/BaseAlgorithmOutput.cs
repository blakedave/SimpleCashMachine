using System;
using System.Collections.Generic;
using System.Text;

namespace CashMachineLib
{
    public class BaseAlgorithmOutput : IAlgorithmOutput
    {
        public string Output { get; set; }
        public double Balance { get; set; }
    }
}
