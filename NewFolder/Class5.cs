using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TestExample.NewFolder
{
    //Burada özellikle dikkat edilmesi gereken nokta şudur ki, xUnit.Net her birim testi için bulunduğu sınıfın bir instance’ını almaktadır. Haliyle bu örnekte dört farklı metot olduğuna göre test sürecinde dört farklı nesne oluşturuldu demektir.Dolayısıyla xUnit.Net, her bir birim için instance üretmesinden dolayı bir test bitmeden diğerine geçmeyecektir.

    //instance’ı tek seferde constructor üzerinden de oluşturabiliriz.
    public class MathematicsTest5
    {
        Mathematics _mathematics;
        public MathematicsTest5()
        {
            _mathematics = new();
        }
        [Theory]
        [ClassData(typeof(TypeSafeData))]
        public void SumTest(int number1, int number2, int expected)
        {
            #region Act
            int result = _mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }
        [Fact]
        public void SubtractTest()
        {
            #region Arrange
            int number1 = 10;
            int number2 = 20;
            int expected = -10;
            #endregion
            #region Act
            int result = _mathematics.Subtract(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }
        [Theory, InlineData(3, 5)]
        public void MultiplyTest(int number1, int number2)
        {
            #region Act
            int result = _mathematics.Multiply(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(15, result);
            #endregion
        }
        [Theory, InlineData(30, 5, 6)]
        public void DivideTest(int number1, int number2, int expected)
        {
            #region Act
            int result = _mathematics.Divide(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }
    }
}
