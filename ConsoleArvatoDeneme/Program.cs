using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleArvatoDeneme
{
    class Program
    {
        //Kayıt ve Listeleme işleminde kullanılmak üzere oluşturduğum diziler.. Global'de tanımladım çünkü her metot içerisinde tekrar yazmak istemedim.
        public static List<string> tcList = new List<string>();
        public static List<string> name = new List<string>();
        public static List<string> surname = new List<string>();
        public static List<string> gsmNO = new List<string>();
        public static List<string> carBrand = new List<string>();
        public static List<string> carColour = new List<string>();
        public static List<string> carModels = new List<string>();
        public static List<string> carNumber = new List<string>();
      
        //Switch yapısı için gerekli olan char veri türleri
        public static char process;
        public static char car_process;
        public static char list_process;

        static void Main(string[] args)
        {
            Menu();
        }
        public static void List() 
        {
            //if'in içerisinde belirtmiş olduğum Count == 0 , kullanıcı kayıt yapmadan listemelek istediğinde program izin vermeyecek ve kayıt ekranına yönlendirecektir.
            //Sadece kayıt yapılmış işlemler için listeme tarafına ulaşım sağlanacaktır.
            if(tcList.Count==0 && name.Count==0 && surname.Count==0 && gsmNO.Count==0 && carBrand.Count==0 && carColour.Count==0 && carModels.Count==0 && carNumber.Count==0) 
            {
                Console.WriteLine("Kayıt işlemi yapılmadan listeler görüntülenemez ! ");
                Console.WriteLine("Lütfen kayıt işlemi yapınız.\n Menüye dönmek için Enter tuşuna basınız.");
                Console.ReadKey();
                Menu();
            }
            else 
            {
                foreach (string item in tcList)
                {
                    Console.WriteLine("TC NO: {0} ", item);
                }
                foreach (string item in name)
                {
                    Console.WriteLine("AD: {0}", item);
                }
                foreach (string item in surname)
                {
                    Console.WriteLine("SOYAD: {0}", item);
                }
                foreach (string item in gsmNO)
                {
                    Console.WriteLine("GSM NO: {0}", item);
                }
                foreach (string item in carBrand)
                {
                    Console.WriteLine("ARABA MARKASI: {0}", item);
                }
                foreach (string item in carColour)
                {
                    Console.WriteLine("ARABA RENGİ: {0}", item);
                }
                foreach (string item in carModels)
                {
                    Console.WriteLine("ARABA MODELİ: {0}", item);
                }
                foreach (string item in carNumber)
                {
                    Console.WriteLine("ARABA SAYISI: {0}", item);
                }

                Console.WriteLine("Ana menüye dönmek için 1 ' e. \n Programdan çıkış yapmak için 2'ye basınız.");

                list_process = Convert.ToChar(Console.ReadLine());

                switch (list_process)
                {
                    case '1':
                        Menu();
                        break;
                    case '2':
                        Exit();
                        break;
                }
            }

           


        }
        public static void Record() 
        {
            Console.WriteLine("Lütfen işlem yapmak istediğiniz \n Tc numarasını giriniz.");
            string enteredValue = Console.ReadLine();

            //Kullanıcı aynı tc numarasına ait bir değer girdiği vakit if içerisine düşecek ve izin vermeyecektir.Aksi durumda kayıt işlemine devam edebilecektir.
            if (tcList.Contains(enteredValue))
            {
                Console.WriteLine("Bu Tc Numarasına ait müşteri kaydı oluşturulmuştur.\n");
                List();
            }
            else
            {
                tcList.Add(enteredValue);
                Console.WriteLine("Lütfen isim girişi yapınız.\n");
                string nameValue = Console.ReadLine();
                name.Add(nameValue);
                Console.WriteLine("Lütfen soyad girişi yapınız. \n");
                string surnameValue = Console.ReadLine();
                surname.Add(surnameValue);
                Console.WriteLine("Lütfen müşteri GSM no girişi yapınız.");
                string gsmValue = Console.ReadLine();
                gsmNO.Add(gsmValue);
                Console.WriteLine("Kayıt yapılmıştır.Ana Menüye yönlendiriliyorsunuz. \n Lütfen Enter tuşuna basınız.");
                Console.ReadKey();
                Menu();

            }

            
        }
        public static void Menu() 
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Araba Kayıt Programına Hoş Geldiniz.");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1-Kayıt \n");
            Console.WriteLine("2-Araba İşlemleri \n");
            Console.WriteLine("3-Kayıtları Listeleme \n");
            Console.WriteLine("4-Çıkış \n");

            process = Convert.ToChar(Console.ReadLine());

            switch (process)
            {
                case '1':
                    Record();
                    break;
                case '2':
                    CarProcess();
                    break;
                case '3':
                    List();
                    break;
                case '4':
                    Exit();
                    break;

            }
        }
        public static void Exit() 
        {
            Environment.Exit(0);
        }
        public static void CarProcess() 

        {
            // if içerisinde belirtmiş olduğum count==0 , kullanıcı kayıt yapmadan araba işlemlerine erişmek istediğinde hata verecektir. isim , soyisim ve gsm ile kayıt oluşturulduğu için bu listelerin içi boş olunca kayıt yoktur demektir . Aksi durumda işleme devam edebilecektir.
            if(name.Count==0 && surname.Count==0 && gsmNO.Count == 0) 
            {
                Console.WriteLine("Kayıt yapılmadan araba satın alınamaz !");
                Console.WriteLine("Kayıt sayfasına gitmek için Enter tuşuna basınız.");
                Console.ReadKey();
                Record();
            }
            else 
            {
                //Kullanıcı istediği araba markasına 1-6 arası rakamları tuşlayarak erişebilecektir.
                string bmw = "BMW", audi = "Audi", mercedes = "Mercedes", toyota = "Toyota", ford = "Ford", ferrari = "Ferrari";
                Console.WriteLine("Lütfen almak istediğiniz araba markasını belirtiniz.\n");
                Console.WriteLine("1-BMW");
                Console.WriteLine("2-Audi");
                Console.WriteLine("3-Mercedes");
                Console.WriteLine("4-Ford");
                Console.WriteLine("5-Ferrari");
                Console.WriteLine("6-Toyota");

                car_process = Convert.ToChar(Console.ReadLine());

                switch (car_process)
                {
                    case '1':
                        //Kullanıcı araba renk,model ve kaç tane alacağına dair değerleri klavyeden girebilecektir.
                        //Aynı işlemler tüm araba markaları için tekrarlanmıştır.
                        carBrand.Add(bmw);
                        Console.WriteLine("Lütfen istediğiniz araba rengini yazınız. \n");
                        string car_colour = Console.ReadLine();
                        carColour.Add(car_colour);
                        Console.WriteLine("Almak istediğiniz araba modelini yazınız \n Örnek: 2005 Model");
                        string car_models = Console.ReadLine();
                        carModels.Add(car_models);
                        Console.WriteLine("Bu arabadan kaç tane almak istersiniz ? ");
                        string howMany = Console.ReadLine();
                        carNumber.Add(howMany);

                        Console.WriteLine("Araba kaydınız tamamlanmıştır.");
                        Console.WriteLine("Geri dönmek için enter'la");
                        Console.ReadLine();
                        Menu();
                        break;

                    case '2':
                        carBrand.Add(audi);
                        Console.WriteLine("Lütfen istediğiniz araba rengini yazınız. \n");
                        string car_colour1 = Console.ReadLine();
                        carColour.Add(car_colour1);
                        Console.WriteLine("Almak istediğiniz araba modelini yazınız \n Örnek: 2005 Model");
                        string car_models1 = Console.ReadLine();
                        carModels.Add(car_models1);
                        Console.WriteLine("Bu arabadan kaç tane almak istersiniz ? ");
                        string howMany1 = Console.ReadLine();
                        carNumber.Add(howMany1);

                        Console.WriteLine("Araba kaydınız tamamlanmıştır.");
                        Console.WriteLine("Geri dönmek için enter'la");
                        Console.ReadLine();
                        Menu();
                        break;

                    case '3':
                        carBrand.Add(mercedes);
                        Console.WriteLine("Lütfen istediğiniz araba rengini yazınız. \n");
                        string car_colour2 = Console.ReadLine();
                        carColour.Add(car_colour2);
                        Console.WriteLine("Almak istediğiniz araba modelini yazınız \n Örnek: 2005 Model");
                        string car_models2 = Console.ReadLine();
                        carModels.Add(car_models2);
                        Console.WriteLine("Bu arabadan kaç tane almak istersiniz ? ");
                        string howMany2 = Console.ReadLine();
                        carNumber.Add(howMany2);

                        Console.WriteLine("Araba kaydınız tamamlanmıştır.");
                        Console.WriteLine("Geri dönmek için enter'la");
                        Console.ReadLine();
                        Menu();
                        break;

                    case '4':
                        carBrand.Add(ford);
                        Console.WriteLine("Lütfen istediğiniz araba rengini yazınız. \n");
                        string car_colour3 = Console.ReadLine();
                        carColour.Add(car_colour3);
                        Console.WriteLine("Almak istediğiniz araba modelini yazınız \n Örnek: 2005 Model");
                        string car_models3 = Console.ReadLine();
                        carModels.Add(car_models3);
                        Console.WriteLine("Bu arabadan kaç tane almak istersiniz ? ");
                        string howMany3 = Console.ReadLine();
                        carNumber.Add(howMany3);

                        Console.WriteLine("Araba kaydınız tamamlanmıştır.");
                        Console.WriteLine("Geri dönmek için enter'la");
                        Console.ReadLine();
                        Menu();
                        break;
                    case '5':
                        carBrand.Add(ferrari);
                        Console.WriteLine("Lütfen istediğiniz araba rengini yazınız. \n");
                        string car_colour4 = Console.ReadLine();
                        carColour.Add(car_colour4);
                        Console.WriteLine("Almak istediğiniz araba modelini yazınız \n Örnek: 2005 Model");
                        string car_models4 = Console.ReadLine();
                        carModels.Add(car_models4);
                        Console.WriteLine("Bu arabadan kaç tane almak istersiniz ? ");
                        string howMany4 = Console.ReadLine();
                        carNumber.Add(howMany4);

                        Console.WriteLine("Araba kaydınız tamamlanmıştır.");
                        Console.WriteLine("Geri dönmek için enter'la");
                        Console.ReadLine();
                        Menu();
                        break;
                    case '6':
                        carBrand.Add(toyota);
                        Console.WriteLine("Lütfen istediğiniz araba rengini yazınız. \n");
                        string car_colour5 = Console.ReadLine();
                        carColour.Add(car_colour5);
                        Console.WriteLine("Almak istediğiniz araba modelini yazınız \n Örnek: 2005 Model");
                        string car_models5 = Console.ReadLine();
                        carModels.Add(car_models5);
                        Console.WriteLine("Bu arabadan kaç tane almak istersiniz ? ");
                        string howMany5 = Console.ReadLine();
                        carNumber.Add(howMany5);

                        Console.WriteLine("Araba kaydınız tamamlanmıştır.");
                        Console.WriteLine("Geri dönmek için enter'la");
                        Console.ReadLine();
                        Menu();
                        break;

                }
            }
            


        }
       
    }
}
