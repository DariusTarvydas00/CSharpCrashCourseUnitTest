using System;
using System.Linq;
using Xunit.Sdk;

namespace CrashCourse2021ExercisesDayOne.Utils
{
    internal class StringUtil
    {
        internal int LengthOfString(string stringToMeasure)
        {
            if (stringToMeasure == null)
            {
                throw new NullReferenceException(Constants.StringCannotBeNull);
            }

            return stringToMeasure.Length;
        }

        internal string SumStrings(string value1, string value2)
        {
            return (int.Parse(value1) + int.Parse(value2)).ToString();
        }

        internal string DivideString(string value1, string value2)
        {
            return (Int32.Parse(value1)/Int32.Parse(value2)).ToString();
        }

        internal string StringContains(string value1, string value2)
        {
            return (value1.Contains(value2)) ? Constants.AnswerYes : Constants.AnswerNo;
        }

        internal string StringToUpperCase(string value1)
        {
            return value1.ToUpper();
        }

        internal string AdditionFromPlusString(string inputString)
        {
            var total = 0;
            foreach (var strings in inputString.Split('+'))
            {
                total += int.Parse(strings);
            }

            return total.ToString();
        }

        internal string EvenNumber(int numbertoTest)
        {
            return (numbertoTest % 2 == 0) ? Constants.Even : Constants.Odd;
        }
    }
}