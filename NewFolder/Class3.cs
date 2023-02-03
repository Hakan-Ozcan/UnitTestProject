using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExample.NewFolder
{
    public class Datas2 : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 3, 5, 8 };
            yield return new object[] { 11, 5, 16 };
            yield return new object[] { 23, 2, 25 };
            yield return new object[] { 33, 44, 87 };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class MathematicsTest3
    {
        [Theory]
        //Ayrıca ‘MemberData’ attribute’una alternatif olarak ‘ClassData’ attribute’unu da kullanabiliriz.
        //Tabi ‘ClassData’ attribute’u, dataları alacağı sınıfa IEnumerable<object[]> arayüzünü implemente etmemizi ve ‘GetEnumerator’ içerisinde yield ile dataları itere etmemizi istemektedir.
        [ClassData(typeof(Datas2))]
        public void SumTest3(int number1, int number2, int expected)
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
