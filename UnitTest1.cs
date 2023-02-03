using System.Runtime.ConstrainedExecution;

namespace TestExample
{
    //Peki, testler paralel bir �ekilde �al��t�r�labilir mi?Testleri paralel �al��t�rabilmek i�in her bir unit testi ayr� bir s�n�fa almam�z gerekecektir.

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
        //Testleri paralel �al��t�rabilmek i�in her bir unit testi ayr� bir s�n�fa almam�z gerekecektir.

    }
    public class TestA
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(5000);
        }
    }
    //Her iki testi�de ayr� class�lara al�rsak iki s�n�f i�inde instance olu�turulacak ve test s�reci paralel ba�lat�lacakt�r. Dolay�s�yla totalde her iki test�te 5�er saniye paralelde y�r�t�lece�i i�in 5 saniyelik bir maliyet olu�acakt�r.

    //xUnit.Net k�t�phanesi burada her bir class�� farkl� bir �Collection� olarak de�erlendirmektedir. �Collection�� esas�nda bir instance ile aya�a kald�r�lacak test toplulu�u gibi d���nebiliriz.

    //Hatta ayr� s�n�flar� tek bir collection alt�nda toplayarak yine tek bir instance �zerinden single thread�de �al��mas�n� sa�layabiliriz.
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
    //Tabi ki de bu durum pek tercih edilir olmasa gerek� Nihayetinde ne kadar �ok class�� tek bir collection alt�nda toplarsak testlerin tamamlanma s�resi o kadar uzayacakt�r.
}