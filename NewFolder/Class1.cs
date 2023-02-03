using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExample.NewFolder
{
    public class Class1
    {

        public static IEnumerable<object[]> sumDatas => new List<object[]> {
    new object[]{ 3, 5, 8 },
    new object[]{ 11, 5, 16 },
    new object[]{ 23, 2, 25 },
    new object[]{ 33, 44, 87 }
};

        [Theory]
        //Eğer ki test edilecek data miktarı haddinden fazla ise ‘InlineData’ ile bunu yapmak mümkün olsa da yersiz kod maliyetine sebep olabilmektedir. Böyle durumlarda ‘MemberData’ attribute’unu kullanabilirsiniz.
        [MemberData(nameof(sumDatas))]
        public void SumTest(int number1, int number2, int expected)
        {
            #region Arrange
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            int result = mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }
    }
}
