using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CashMachineLib
{
    public class AlgorithmContext : IAlgorithm
    {
        public AlgorithmContext(CultureInfo culture)
        {
            Culture = culture;
            Switch<AlgorithmOne>();
        }

        private IAlgorithm CurrentAlgorithm { get; set; }

        public CultureInfo Culture { get; }

        public void Switch<T>() where T : IAlgorithm
        {
            var currentType = CurrentAlgorithm != null ? CurrentAlgorithm.GetType() : this.GetType();

            if (currentType != typeof(T))
            {
                CurrentAlgorithm = (T)Activator.CreateInstance(typeof(T), Culture);
            }
        }

        public IAlgorithmOutput Withdraw(double amount)
        {
            return CurrentAlgorithm.Withdraw(amount);
        }

        public Type CurrentAlgorithType { get => CurrentAlgorithm.GetType(); }

        public double Balance => CurrentAlgorithm.Balance;
    }
}
