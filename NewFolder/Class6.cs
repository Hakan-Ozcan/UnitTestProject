using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestExample.NewFolder
{

    //Peki buradaki instance üretim maliyetini düşürebilir miyiz?
    //xUnit.Net’te üretilecek olan instance’ların üretim maliyetini düşürebilmek için ilgili sınıftan tek bir nesne üretilmeli ve tüm birim testlerinde o nesne kullanılmalıdır. Bunun için ‘IClassFixture’ interface’i kullanılabilir.
    //Görüldüğü üzere test sınıfını bu şekilde ‘IClassFixture’ arayüzünden implemente ettirmemiz instance maliyeti açısından yeterli olacaktır. Geri kalanını xUnit.Net halledecektir.

    public class MathematicsTest6 : IClassFixture<Mathematics>
    {
        Mathematics _mathematics;
        public MathematicsTest6(Mathematics mathematics)
        {
            _mathematics = mathematics;
        }
        [Theory]
        [ClassData(typeof(TypeSafeData))]
        public void SumTest(int number1, int number2, int expected)
        {
            Task.Delay(5000).Wait();
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
            Task.Delay(5000).Wait();
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
            Task.Delay(5000).Wait();
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
            Task.Delay(5000).Wait();
            #region Act
            int result = _mathematics.Divide(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }
    }
}
