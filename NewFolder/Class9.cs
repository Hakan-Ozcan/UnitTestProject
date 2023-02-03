using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExample.NewFolder
{
    public class MathematicsTest7
    {
        [Fact]
        public void SumTest()
        {
            int result = 0;

            var mathematics = new Mock<IMathematics>();
            mathematics.Setup(m => m.Sum(It.IsAny<int>(), It.IsAny<int>()))
                .Callback<int, int>((number1, number2) => result = number1 + number2);//‘Setup’ edilen ‘Sum’ fonksiyonunun parametreleri ‘It.IsAny<T>’ ile işaretlenerek optisonel olarak int türünden değerler alacağı bildirilmekte ve ‘Callback’ fonksiyonu ile bu alınan değerler üzerinde yapılacak işlem belirtilmektedir
            //Burada gelen değerler toplanmakta ve sonuçları ‘result’ değişkenine atanmaktadır

            //Bu aşamadan sonra artık ‘Object’ üzerinden çağrılan her bir ‘Sum’ fonksiyonu, verilen değerlere göre ‘result’ değişkenine işlem sonucunu assign edecektir. Haliyle her bir Assert bu sonuçlara göre değerlendirilmektedir.
            mathematics.Object.Sum(1, 2);
            Assert.Equal(3, result);

            mathematics.Object.Sum(5, 5);
            Assert.Equal(10, result);

            mathematics.Object.Sum(15, 5);
            Assert.Equal(20, result);

            mathematics.Object.Sum(23, 2);
            Assert.Equal(25, result);
        }
    }
    public class MathematicsTest8
    {
        [Fact]
        public void SumTest()
        {
            int result = 0;

            var mathematics = new Mock<IMathematics>();
            //Moq.Range.Inclusive : 1 ile 10'da dahil.
            //Moq.Range.Exclusive : 1 ile 10'da dahil değil.
            mathematics.Setup(m => m.Sum(It.IsInRange<int>(1, 10, Moq.Range.Inclusive), It.IsInRange<int>(1, 10, Moq.Range.Inclusive)))
                .Returns(-5);//Misal, bazen de belli bir aralıkta gelecek olan değerlere göre sürekli sabit bir işlem gerçekleştirebilir yahut değer dönebiliriz. Bunun içinde It.IsInRange<int> kullanılabilir.

            mathematics.Object.Sum(1, 2);
            Assert.Equal(-5, result); //Ok

            mathematics.Object.Sum(5, 5);
            Assert.Equal(-5, result); //Ok

            mathematics.Object.Sum(15, 5);
            Assert.Equal(-5, result); //Fail

            mathematics.Object.Sum(23, 2);
            Assert.Equal(-5, result); //Fail
        }
    }
    public interface ISamplee
    {
        int Check();
    }
    public class Samplee : ISamplee
    {
        public int Check()
        {
            return 5;
        }
    }
    public class SampleTestt
    {
        [Fact]
        public void Sample_Test()
        {
            var sample = new Mock<ISample>();
            sample.SetupSequence(m => m.Check())//Ayrıca ‘SetupSequence’ ile bir metodu her çağrıldığında farklı değerler döndürecek şekilde mocklayabiliriz.
                .Returns(-5)
                .Returns(-10)
                .Returns(15);

            var result1 = sample.Object.Check(); //-5
            var result2 = sample.Object.Check(); //-10
            var result3 = sample.Object.Check(); //15

            Assert.Equal(-5, result1);
            Assert.Equal(-10, result2);
            Assert.Equal(15, result3);
        }
    }
    public class SampleTesttt
    {
        [Fact]
        public void Sample_Test()
        {
            var sampleMock = new Mock<ISamplee>();
            //İlk değer 125 olarak atanıyor.
            sampleMock.SetupProperty(s => s.SampleProperty, 125);
            //Tabi süreçte farklı değerde set edebiliyoruz.
            sampleMock.Object.SampleProperty = 55;
            var result = sampleMock.Object.SampleProperty;
            Assert.Equal(55, result);
            ///////////////////////////////////////////////
            var sampleMockt = new Mock<ISample>();
            sampleMock.SetupAllProperties();//Eğer ki test edilecek olan property sayısı haddinden fazlaysa her birini tek tek bu şekilde setuplamamak için aşağıdaki gibi ‘SetupAllProperties’ini de kullanabiliriz.
        }

    }
    public class SampleTesttttt
    {
        [Fact]
        public void Sample_Test()
        {
            var sampleMock = new Mock<ISamplee>();
            sampleMock.SetupGet(x => x.SampleProperty)//Peki setter’ı olmayan property’leri nasıl simüle edebiliyoruz?Bunun içinde ‘SetupGet’ metodu kullanılabilmektedir.

                .Returns(55);
            var result = sampleMock.Object.SampleProperty; //55
            Assert.Equal(55, result);
        }
    }
    public class SampleTest5
    {
        //Ayrıca property’e istediğimiz değerin set edilip edilmediğini kontrol etmemiz gerekirse eğer;
        [Fact]
        public void Sample_Test()
        {
            var sampleMock = new Mock<ISample>();
            sampleMock.SetupProperty(x => x.SampleProperty);
            sampleMock.Object.SampleProperty = 55;

            sampleMock.VerifySet(x => x.SampleProperty = 55);
        }
    }
    public class SampleTest7
    {
        //Bunların dışında herhangi bir property’nin değerinin read edilip edilmediğini de aşağıdaki gibi kontrol edebiliriz;
        [Fact]
        public void Sample_Test()
        {
            var sampleMock = new Mock<ISamplee>();
            sampleMock.SetupProperty(x => x.SampleProperty);
            sampleMock.Object.SampleProperty = 55;
            //Burada property değerini get ediyoruz.
            var result = sampleMock.Object.SampleProperty;
            //Dolayısıyla aşağıdaki doğrulama başarılı olacak ve testten geçilecektir.
            sampleMock.VerifyGet(x => x.SampleProperty);
        }
    }


}
