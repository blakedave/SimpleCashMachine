using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CashMachineLib
{
    public class AlgorithmContext : IAlgorithmContext, IAlgorithm
    {
        private AlgorithmContext()
        { /* */ }

        private IAlgorithm CurrentAlgorithm { get; set; }

        public CultureInfo Culture { get; private set; }

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

        public Type CurrentAlgorithmType { get => CurrentAlgorithm.GetType(); }

        public double Balance => CurrentAlgorithm.Balance;

        public static IAlgorithmContext GetInitialised<T>(CultureInfo culture) where T : IAlgorithm
        {
            var context = new AlgorithmContext
            {
                Culture = culture
            };
            context.Switch<T>();
            return context;
        }
    }
}
