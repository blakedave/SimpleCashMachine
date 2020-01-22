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
            var context = new AlgorithmContext(CultureInfo.GetCultureInfo("en-GB"));

            Assert.Equal(typeof(AlgorithmOne), context.CurrentAlgorithType);
        }
        
        [Fact]
        public void AfterSwitchCurrentAlgorithmIsAlgorithmTwo()
        {
            var context = new AlgorithmContext(CultureInfo.GetCultureInfo("en-GB"));
            context.Switch<AlgorithmTwo>();

            Assert.Equal(typeof(AlgorithmTwo), context.CurrentAlgorithType);
        }
    }
}
