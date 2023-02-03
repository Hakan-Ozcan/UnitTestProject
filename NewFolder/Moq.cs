using Moq; //Nuget dan indirmemiz gerekiyor
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExample.NewFolder
{
    //bir sınıfı nasıl Mocking yapabiliriz?
    //Bir sınıfı mocklayabilmek için o sınıfın implemente ettiği interface kullanılmalıdır. Aksi taktirde bunun dışında bir yapılanmayı denemek ilgili uygulamanın derleme aşamasında hata almasına sebep olacaktır…
    //Şimdi aşağıdaki ‘Sum’ metodunu ele alırsak eğer görüldüğü üzere toplama işlemini filanca sebeplerden dolayı 5 saniye zarfında yaptığını görmekteyiz ,Haliyle her test sürecinde bu 5 saniyeyi beklemek mecburiyetinde kalacağız.
    public interface IMathematics
    {
        int Sum(int number1, int number2);
    }
    public class MathematicsForMoq : IMathematics
    {
        public int Sum(int number1, int number2)
        {
            Thread.Sleep(5000);
            return number1 + number2;
        }
    }
    public class MathematicsTestForMoq
    {
        [Fact]
        public void SumTest()
        {
            var mathematics = new Mock<IMathematics>();//‘Mock’ sınıfına generic olarak ‘IMathematics’ interface’i verilmekte ve böylece hangi interface içerisindeki metotların simüle edileceği bildirilmiş olunmaktadır
            mathematics.Setup(m => m.Sum(1, 2))//burada ilgili interface içerisinde simüle edilecek olan metot ‘Setup’ edilmekte ve böylece simüle sürecinde verilecek ‘1’ ve ‘2’ parametre değerlerine karşı geriye ‘3’ değerinin dönmesi gerektiği bildirilmektedir.
                .Returns(3);
            int result = mathematics.Object.Sum(1, 2);//burada artık simülasyon ayarları bitmiş olan ‘Mock’ nesnesi üzerinden ‘Object’ property’si ile üretilen nesne çağrılmakta ve ilgili metot tetiklenmektedir

            Assert.Equal(3, result);
           //Ve sonuç olarak ilgili metot milisaniye cinsinden kısa bir sürede test edilmiş olacaktır.
        }
    }
    public class MathematicsTestt
    {
        [Fact]
        public void SumTest()
        {
            var mathematics = new Mock<IMathematics>();
            mathematics.Setup(m => m.Sum(1, 2))
                .Returns(3);
            int result = mathematics.Object.Sum(1, 2);

            Assert.Equal(3, result);
            //aşağıda ‘Sum’ metodunun iki kere çalıştırılması durumunda testten geçeceği bildirilmiştir. Ayrıca ‘Verify’ metodu sayesinde teste tabi tutulan metodun içerisinde çalıştırılan farklı metotlarında çalıştırılıp çalıştırılmadığını test edebiliriz.

            mathematics.Verify(x => x.Sum(1, 2), Times.AtLeast(2));// verify=Bir metodun kaç kez çalıştığını test edebilmek için kullanılan metottur.
        }
    }
}
