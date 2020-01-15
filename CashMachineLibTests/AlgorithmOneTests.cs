using CashMachineLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

namespace CashMachineLibTests
{
    public class AlgorithmOneTests
    {
        [Fact]
        public void InitialBalanceEqual4638()
        {
            var context = new AlgorithmContext(CultureInfo.GetCultureInfo("en-GB"));

            Assert.Equal(4638.00, context.Balance);
        }

        [Fact]
        public void WithdrawReturnsMsgIfAmountGreaterThanBalance()
        {
            var context = new AlgorithmContext(CultureInfo.GetCultureInfo("en-GB"));

            var input = 5000;
            var output = context.Withdraw(input);

            Assert.Equal("Insufficient funds!", output.Output);
        }

        [Fact]
        public void WithdrawReturnsBalanceEqualToContextBalance()
        {
            var context = new AlgorithmContext(CultureInfo.GetCultureInfo("en-GB"));

            var input = 5000;
            var output = context.Withdraw(input);

            Assert.Equal(context.Balance, output.Balance);
        }

        [Theory]
        [InlineData(120, "£50 x 2, £20 x 1")]
        [InlineData(150, "£50 x 3")]
        [InlineData(135, "£50 x 2, £20 x 1, £10 x 1, £5 x 1")]
        [InlineData(0, "")]
        [InlineData(120.50, "£50 x 2, £20 x 1, 50p x 1")]
        [InlineData(1.50, "£1 x 1, 50p x 1")]
        [InlineData(0.29, "20p x 1, 5p x 1, 2p x 2")]
        public void ReturnsExpectedOutput(double input, string expectedOutput)
        {
            var context = new AlgorithmContext(CultureInfo.GetCultureInfo("en-GB"));

            var output = context.Withdraw(input);

            Assert.Equal(expectedOutput, output.Output);
        }


    }
}
