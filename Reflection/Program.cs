using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {

        Ornek ornek = new Ornek("Toplama1");

        // Reflection Kullanarak Tip bilgilerini aldık.
        Type nesneTipi = ornek.GetType();
        Console.WriteLine("Ad : {0}", nesneTipi.Name);
        Console.WriteLine("Temel Tip : {0}", nesneTipi.BaseType);

        // Assembly Bilgisi Alındı.
        Console.WriteLine(nesneTipi.Assembly);

        //Reflection Kullanarak Property Değerine erişildi.
        PropertyInfo propertyInfo = nesneTipi.GetProperty("FonkisyonAdi");
        Console.WriteLine("Property Değeri : {0}", propertyInfo.GetValue(ornek));

        //Method bilgisini kullanarak methoda erişim sağlandı. Ve method ınvoke edilerek method çalıştırıldı.
        MethodInfo methodInfo = nesneTipi.GetMethod("Topla");
        object[] parametreler = { 100, 200 };
        methodInfo.Invoke(ornek, parametreler);
    }


    public class Ornek
    {
        public string FonkisyonAdi { get; set; }

        public Ornek(string fonkAdi)
        {
            FonkisyonAdi = fonkAdi;
        }
        public int Topla(int a, int b)
        {
            Console.WriteLine(a + b);
            return a + b;
        }
    }
}