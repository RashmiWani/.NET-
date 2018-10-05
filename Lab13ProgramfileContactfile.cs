using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab13Q1
{
    class Program
    {
        public static void PrintMenu()
        {

            Console.WriteLine("\n1. Add Contact");
            Console.WriteLine("2. ShowAll Contacts");
            Console.WriteLine("3. Exit");
          

        }

        public static void AddContact(ref List<Contact> MyContactList)
        {
            Contact NewContact = new Contact();

            Console.Write("Enter Contact Number : ");
            NewContact.ContactNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Contact Name : ");
            NewContact.ContactName = Console.ReadLine();

            Console.Write("Enter Cell Number : ");
            NewContact.CellNo = Console.ReadLine();
            MyContactList.Add(NewContact);

            
        }
        
        public static void ShowAllContacts(ref List<Contact> MyContactList)
        {
            if (MyContactList != null)
            {

                
                foreach (Contact SavedContact in MyContactList)
                {
                    
                    Console.WriteLine("Contact No. : " + SavedContact.ContactNo);
                    Console.WriteLine("Contact Name : " + SavedContact.ContactName);
                    Console.WriteLine("Cell No. : " + SavedContact.CellNo);
                }

            }
            else
                Console.WriteLine("No Details Saved Yet Please SAve Some Contatcs Fitrst");
        }

        static void Main(string[] args)
        {
            int choice;
            List<Contact> MyContactList = new List<Contact>();
            
            do
            {
                Console.Write("\nChoose Operation :  ");
                PrintMenu();
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Program.AddContact(ref MyContactList);
                        FileStream fs = new FileStream("binary.txt", FileMode.Create, FileAccess.Write);
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(fs, MyContactList);
                        fs.Close();
                        Console.WriteLine("Serialization Done");
                        break;
                    case 2:
                         fs = new FileStream("binary.txt", FileMode.Open, FileAccess.Read);
                        BinaryFormatter bn = new BinaryFormatter();
                        List<Contact> MyContactLis= (List<Contact>)bn.Deserialize(fs);
                        fs.Close();
                        Program.ShowAllContacts(ref MyContactLis);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                   
                    default:
                        Console.WriteLine("enter A Valid Choice");
                        break;

                }
            }
            while (choice != 3);

        }
    }
}
