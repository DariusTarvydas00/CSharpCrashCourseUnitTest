using Xunit;

namespace CrashCourse2021ExercisesDayTwo.Tests
{
    public class ConstantsTest
    {
        [Fact]
        public void ConstantToAddMustBeZeroOrMoreTest()
        {
            Assert.Equal("Credit Value to Add must be zero or more", Constants.CreditToAddMustBeZeroOrMoreException);
        }

        [Fact]
        public void ConstantCreditCannotExceedMaxValueExceptionTest()
        {
            Assert.Equal("Credit Value cannot Exceed Max Value", Constants.CreditCannotExceedMaxValueException);
        }

        [Fact]
        public void ConstantToRemoveMustBeZeroOrMoreTest()
        {
            Assert.Equal("Credit Value to Remove must be zero or more", Constants.CreditToRemoveMustBeZeroOrMoreException);
        }

        [Fact]
        public void ConstantCreditToRemoveMustBeZeroOrMoreExceptionTest()
        {
            Assert.Equal("Credit Value cannot Be Less Then Zero", Constants.CreditCannotBeLessThenZeroException);
        }

        


    }
}
