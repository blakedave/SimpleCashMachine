using CashMachineLib;
using System;
using System.Globalization;
using Xunit;

namespace CashMachineLibTests
{
    public class AlgorithmContextTests
    {
        [Fact]
        public void DefaultAlgorithmIsAlgorithmOne()
        {
            var context = AlgorithmContext.GetInitialised<AlgorithmOne>(CultureInfo.GetCultureInfo("en-GB"));

            Assert.Equal(typeof(AlgorithmOne), context.CurrentAlgorithmType);
        }
        
        [Fact]
        public void AfterSwitchCurrentAlgorithmIsAlgorithmTwo()
        {
            var context = AlgorithmContext.GetInitialised<AlgorithmOne>(CultureInfo.GetCultureInfo("en-GB"));
            context.Switch<AlgorithmTwo>();

            Assert.Equal(typeof(AlgorithmTwo), context.CurrentAlgorithmType);
        }
    }
}
