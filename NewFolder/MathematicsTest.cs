using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExample.NewFolder
{
    public class MathematicsTest
    {
        [Fact]
        public void SubtractTest()
        {
            #region Arrange
            //Kaynaklar hazırlanıyor.
            int number1 = 10;
            int number2 = 20;
            int expected = -10;
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            //İlgili metot Arrange'de ki kaynaklarla test ediliyor.
            int result = mathematics.Subtract(number1, number2);
            #endregion
            #region Assert
            //Test neticesinde gelen data doğrulanıyor.
            Assert.Equal(expected, result);
            #endregion
        }
        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(11, 5, 16)]
        [InlineData(23, 2, 25)]
        [InlineData(33, 44, 87)]
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
