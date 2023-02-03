using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExample.NewFolder
{
    public class Datas
    {
        public static IEnumerable<object[]> sumDatas => new List<object[]> {
        new object[]{ 3, 5, 8 },
        new object[]{ 11, 5, 16 },
        new object[]{ 23, 2, 25 },
        new object[]{ 33, 44, 87 }
    };
    }
    public class MathematicsTest2
    {
        [Theory]
        //Eğer ki bu member farklı bir class’ın üyesi olsaydı aşağıdaki gibi ‘MemberType’ property’si üzerinden sınıf bildiriminde bulunarak çalışma yapılması yeterli olacaktı;
        [MemberData(nameof(Datas.sumDatas), MemberType = typeof(Datas), DisableDiscoveryEnumeration = true)]
        //Ayrıca ‘MemberData’ ile yapılan test süreçlerinde veri seti yüzlerce yahut binlerce olanlar için ‘Test Explorer’da tek bir sonuç elde etmek istiyorsak eğer “DisableDiscoveryEnumeration” özelliğine ‘true’ vermemiz yeterli olacaktır.
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
