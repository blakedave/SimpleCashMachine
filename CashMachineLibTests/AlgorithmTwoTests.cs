using CashMachineLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

namespace CashMachineLibTests
{
    public class AlgorithmTwoTests
    {
        [Fact]
        public void WithdrawReturnsMsgIfAmountGreaterThanBalance()
        {
            var context = AlgorithmContext.GetInitialised<AlgorithmTwo>(CultureInfo.GetCultureInfo("en-GB"));
            
            var input = 5000;
            var output = context.Withdraw(input);

            Assert.Equal("Insufficient funds!", output.Output);
        }

        [Theory]
        [InlineData(120, "£20 x 6")]
        [InlineData(150, "£20 x 7")]
        [InlineData(135, "£20 x 6")]
        [InlineData(1001, "£20 x 50")]
        [InlineData(2000, "£20 x 50")]
        [InlineData(19, "Amount must be greater than £20.00")]
        public void ReturnsExpectedOutput(double input, string expectedOutput)
        {
            var context = AlgorithmContext.GetInitialised<AlgorithmTwo>(CultureInfo.GetCultureInfo("en-GB"));

            var output = context.Withdraw(input);

            Assert.Equal(expectedOutput, output.Output);
        }

        [Theory]
        [InlineData(120, 4518)]
        [InlineData(150, 4498)]
        [InlineData(135, 4518)]
        [InlineData(1001, 3638)]
        public void BalanceIsUpdatedCorrectly(double input, double expectedOutput)
        {
            var context = AlgorithmContext.GetInitialised<AlgorithmTwo>(CultureInfo.GetCultureInfo("en-GB"));
            _ = context.Withdraw(input);

            Assert.Equal(expectedOutput, context.Balance);
        }
    }
}
