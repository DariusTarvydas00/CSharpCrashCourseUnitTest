using System;
using CrashCourse2021ExercisesDayTwo.Services;
using Xunit;

namespace CrashCourse2021ExercisesDayTwo.Tests.Services
{
    public class CreditServiceTest
    {
        CreditService creditService;
        public CreditServiceTest()
        {
            this.creditService = new CreditService();
        }

        #region Defaults
        [Fact]
        public void CurrentCredit_AfterInitialization_ReturnsZero()
        {
            Assert.Equal(0d, this.creditService.CurrentCreditValue());
        }
        #endregion

        #region Add Credit
        [Fact]
        public void AddCredit_NegativeValue_ReturnsCannotBeNegativeValueException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => this.creditService.AddCredit(-5));
            Assert.Equal(Constants.CreditToAddMustBeZeroOrMoreException, ex.Message);
        }

        [Fact]
        public void AddCredit_PositveValueGoesAboveMax_ReturnsCannotAddMoreCreditException()
        {
            this.creditService.AddCredit(8000d);
            Exception ex = Assert.Throws<ArgumentException>(() => this.creditService.AddCredit(2005d));
            Assert.Equal(Constants.CreditCannotExceedMaxValueException, ex.Message);
        }


        [Fact]
        public void AddCredit_PositiveValue_ValueIsAdded()
        {
            this.creditService.AddCredit(100);
            Assert.Equal(100, this.creditService.CurrentCreditValue());
        }

        [Theory]
        [InlineData(10d, 10d)]
        [InlineData(0d, 0d)]
        [InlineData(10000d, 10000d)]
        public void MultipleAddCredit_PositiveValue_ValueIsAdded(double expected, double addedValue)
        {
            this.creditService.AddCredit(addedValue);
            Assert.Equal(expected, this.creditService.CurrentCreditValue());
        }
        #endregion

        #region Remove Credit
        [Fact]
        public void RemoveCredit_NegativeValue_ReturnsCannotBeNegativeValueException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => this.creditService.RemoveCredit(-5));
            Assert.Equal(Constants.CreditToRemoveMustBeZeroOrMoreException, ex.Message);
        }

        [Fact]
        public void RemoveCredit_PositveValueGoesBelowZero_ReturnsCannotRemoveCreditException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => this.creditService.RemoveCredit(1d));
            Assert.Equal(Constants.CreditCannotBeLessThenZeroException, ex.Message);
        }

        [Theory]
        [InlineData(1000d, 990d, 10d)]
        [InlineData(1000d, 1000d, 0d)]
        [InlineData(1000d, 0d, 1000d)]
        public void MultipleRemoveCredit_PositiveValue_ValueIsRemoved(double startValue, double expected, double removedValue)
        {
            this.creditService.AddCredit(startValue);
            this.creditService.RemoveCredit(removedValue);
            Assert.Equal(expected, this.creditService.CurrentCreditValue());
        }
        #endregion

        #region Max Value

        [Fact]
        public void CurrentMaxAllowedValue_Default_Returns1000()
        {
            Assert.Equal(10000d, this.creditService.CurrentMaxAllowedValue()) ;
        }

        [Fact]
        public void SetMaxAllowedValue_NegativeValue_ReturnsCreditMaxValueMustBeAboveZeroException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => this.creditService.SetMaxAllowedValue(-5));
            Assert.Equal(Constants.CreditMaxValueMustBeAboveZeroException, ex.Message);
        }

        [Fact]
        public void SetMaxAllowedValue_AboveOneBillion_ReturnsCreditMaxValueCannotBeAboveABillionException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => this.creditService.SetMaxAllowedValue(1000000001d));
            Assert.Equal(Constants.CreditMaxValueCannotBeAboveABillionException, ex.Message);
        }

        [Fact]
        public void SetMaxAllowedValue_PostiveValueAboveZero_SetsMaxAllowedValue()
        {
            var newAllowedMaxValue = 100000d;
            this.creditService.SetMaxAllowedValue(newAllowedMaxValue);
            Assert.Equal(newAllowedMaxValue, this.creditService.CurrentMaxAllowedValue());
        }

        [Theory]
        [InlineData(1d)]
        [InlineData(1000000000d)]
        [InlineData(1000212d)]
        public void MultipleSetMaxAllowedValue_PostiveValueAboveZero_SetsMaxAllowedValue(double value)
        {
            this.creditService.SetMaxAllowedValue(value);
            Assert.Equal(value, this.creditService.CurrentMaxAllowedValue());
        }
        #endregion



    }
}
