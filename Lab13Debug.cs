using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;// add reference
using System.Runtime.Serialization.Formatters.Binary;// add reference
using System.Runtime.Serialization.Formatters; // add reference

namespace Lab13Debug
{   
    [Serializable]//Make class serializable
    class Customer
    {

        public int CustomerID { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }

        [NonSerialized]
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

    }

    class CustomerManager
    {
        static List<Customer> custList = new List<Customer>();

        public CustomerManager()
        {
            custList.Add(new Customer
            {
                CustomerID = 1001,
                Name = "Ramesh",
                Gender = 'M',
                Address = "#104 Mahaveer Springs Mumbai"
            });

            custList.Add(new Customer
            {
                CustomerID = 1002,
                Name = "Ruchi Shah",
                Gender = 'F',
                Address = "#104 Jain Skyline Pune"
            });

          
    }


    public void Serialize(string path)
    {
        FileStream fs = new FileStream(path, FileMode.CreateNew);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, custList);
        Console.WriteLine("Customer List Serialized");
    }

    public void DeSerialize(string path)
    {
        FileStream fs = new FileStream(path, FileMode.Open,FileAccess.Read);// Add fileMode as open and fileAccess as Read
        BinaryFormatter formatter = new BinaryFormatter();
        List<Customer> obj = (List<Customer>)formatter.Deserialize(fs);//use type casting
        fs.Close();
        Print(obj);
    }

    private void Print(List<Customer> obj)
    {
        foreach (Customer item in obj)
        {
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n",
                item.CustomerID, item.Name, item.Gender, item.Address);
        }
    }
}



class Program
    {
        static CustomerManager cm = new CustomerManager(); //Create Object For  CustomerManager Class 
    static void Serialize()
    {
        CustomerManager cm = new CustomerManager();
        Console.WriteLine("Enter the file path.");
        cm.Serialize(Console.ReadLine());
    }

    static void PrintMenu()
    {
        Console.WriteLine("{0}\n{1}\n{2}\n{3}\n\n{4}",
                "Welcome to Serialization Debugging Demo",
                "1. Serailize Data", "2. Deserialize Data",
                "3. Exit the Application.",
                "Enter your choice");
    }
    static void Deserialize()
    {
        Console.WriteLine("Enter the file path.");
        cm.DeSerialize(Console.ReadLine());
    }
    static void Main(string[] args)
    {
        try
        {
            int choice = 0;
            do
            {
                PrintMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Serialize();
                        break;
                    case 2:
                        Deserialize();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (choice != 3);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
            Console.ReadKey();
    }


}
}
