﻿namespace YouTubeDemo_
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *  CreditManager creditManager = new CreditManager();
             *  creditManager.Calculate();
             *  creditManager.Calculate();
             *  creditManager.Save();
             *
             *  Customer customer = new Customer(); //örneğini oluşturmak, instance oluşturmak , instance creation
             *  customer.Id = 1;
             *  customer.city = "Ankara";
             *
             *
             *  CustomerManager customerManager = new CustomerManager(customer);
             *  customerManager.Save();
             *  customerManager.Delete();
             *
             *  Company company = new Company();
             *  company.TextNumber = "100000";
             *  company.CompanyName = "Arçelik";
             *  company.Id = 100;
             *
             *  CustomerManager customerManager2 = new CustomerManager(new Company());
             *
             *  Person person = new Person();
             *  person.Firstname = "";
             *  person.NationalIdentity = "123456";
             *
             *  Customer c1 = new Customer();
             *  Customer c2 = new Person();
             *  Customer c3 = new Company();
             */

            //IoC Container
            CustomerManager customerManager = new CustomerManager(new Customer(), new CarCreditManager());
            customerManager.GiveCredit();

            Console.ReadLine();
        }
    }

    class CreditManager
    {
        public void Calculate(int creditType)
        {
            //sonar qube
            if (creditType == 1)//esnaf
            {

            }
            if (creditType == 2)//ogretmen
            {

            }

            Console.WriteLine("Hesaplandı!");
        }
        public void Save()
        {
            Console.WriteLine("Kredi Verildi!");
        }
    }

    interface ICreditManager
    {
        void Calculate();
        void Save();
    }

    abstract class BaseCreditManager : ICreditManager
    {
        public abstract void Calculate();


        public virtual void Save()
        {
            Console.WriteLine("Kaydedildi!");
        }
    }

    class TeacherCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            //hesaplanmalar
            Console.WriteLine("Öğretmen Kredisi Hesaplandı");
        }

        public override void Save()
        {
            //
            base.Save();
            //
        }
    }
    class MilitaryCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Asker Kredisi Hesaplandı");
        }
    }
    class CarCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Araç Kredisi Hesaplandı");
        }

    }

    //SOLID 
    class Customer
    {
        public Customer()
        {
            Console.WriteLine("Müşteri Nesnesi başlatıldı");
        }
        public int Id { get; set; }
        public string city { get; set; }

        /*
         *   public void Save()
         *   {
         *   Console.WriteLine("Müşteri Kaydedildi!");
         *   }
         */
    }
    class Person : Customer
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string NationalIdentity { get; set; }
    }
    class Company : Customer
    {
        public string CompanyName { get; set; }
        public string TextNumber { get; set; }
    }

    // Katmanlı Mimari
    class CustomerManager
    {
        private Customer _customer;
        private ICreditManager _creditManager;
        public CustomerManager(Customer customer, ICreditManager creditManager)
        {
            _customer = customer;
            _creditManager = creditManager;
        }
        public void Save()
        {

            Console.WriteLine("Müşteri Kaydedildi :");
        }
        public void Delete()
        {

            Console.WriteLine("Müşteri Silindi :");
        }

        public void GiveCredit()
        {
            _creditManager.Calculate();
            Console.WriteLine("Kredi Verildi");
        }
    }

}