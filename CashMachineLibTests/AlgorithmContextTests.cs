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

            Assert.Equal("CashMachineLib.AlgorithmOne", context.CurrentAlgorithType.FullName);
        }

        [Fact]
        public void AfterSwitchCurrentAlgorithmIsAlgorithmTwo()
        {
            var context = new AlgorithmContext(CultureInfo.GetCultureInfo("en-GB"));
            context.Switch<AlgorithmTwo>();

            Assert.Equal("CashMachineLib.AlgorithmTwo", context.CurrentAlgorithType.FullName);
        }
    }
}
