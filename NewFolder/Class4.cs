using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExample.NewFolder
{
    //Peki, IEnumerable<object[]> yerine IEnumerable<string[]> yahut IEnumerable<int[]> gibi tip güvenli test verilerini nasıl yazabiliriz?,Bunun içinde ‘TheoryData’ attribute’undan faydalanabiliriz.

    public class TypeSafeData : TheoryData<int, int, int>
    {
        public TypeSafeData()
        {
            Add(3, 5, 8);
            Add(11, 5, 16);
            Add(23, 2, 25);
            Add(33, 44, 87);
        }
    }
    public class MathematicsTest4
    {
        [Theory]
        [ClassData(typeof(TypeSafeData))]
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
