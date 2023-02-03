using System.Runtime.ConstrainedExecution;

namespace TestExample
{
    //Peki, testler paralel bir þekilde çalýþtýrýlabilir mi?Testleri paralel çalýþtýrabilmek için her bir unit testi ayrý bir sýnýfa almamýz gerekecektir.

    public class Test
    {
       
        [Fact]
        public void Test1()
        {
            Thread.Sleep(5000);
        }
        [Fact]
        public void Test2()
        {
            Thread.Sleep(5000);
        }
        //Testleri paralel çalýþtýrabilmek için her bir unit testi ayrý bir sýnýfa almamýz gerekecektir.

    }
    public class TestA
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(5000);
        }
    }
    //Her iki testi’de ayrý class’lara alýrsak iki sýnýf içinde instance oluþturulacak ve test süreci paralel baþlatýlacaktýr. Dolayýsýyla totalde her iki test’te 5’er saniye paralelde yürütüleceði için 5 saniyelik bir maliyet oluþacaktýr.

    //xUnit.Net kütüphanesi burada her bir class’ý farklý bir ‘Collection’ olarak deðerlendirmektedir. ‘Collection’ý esasýnda bir instance ile ayaða kaldýrýlacak test topluluðu gibi düþünebiliriz.

    //Hatta ayrý sýnýflarý tek bir collection altýnda toplayarak yine tek bir instance üzerinden single thread’de çalýþmasýný saðlayabiliriz.
    public class TestB
    {
        [Fact]
        public void Test2()
        {
            Thread.Sleep(5000);
        }
    }
    [Collection("Collection1")]
    public class TestC
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(5000);
        }
    }
    [Collection("Collection1")]
    public class TestD
    {
        [Fact]
        public void Test2()
        {
            Thread.Sleep(5000);
        }
    }
    //Tabi ki de bu durum pek tercih edilir olmasa gerek… Nihayetinde ne kadar çok class’ý tek bir collection altýnda toplarsak testlerin tamamlanma süresi o kadar uzayacaktýr.
}