using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace ContactManagment
{
    class ContactList
    {
        public static void PrintMenu()
        {
            Console.WriteLine("\n1. Add Contact");
            Console.WriteLine("2. Exit");
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

            FileStream fs = new FileStream("ContactList_SoapSerialized.xml", FileMode.Create, FileAccess.Write);            // or "binay.soap" can be used
            SoapFormatter sin = new SoapFormatter();
            sin.Serialize(fs, NewContact);
            fs.Close();

            MyContactList.Add(NewContact);
        }

        static void Main(string[] args)
        {
           
            List<Contact> MyContactList = new List<Contact>();

            int choice;

            do
            {
                Console.Write("\nChoose Operation :  ");
                PrintMenu();
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ContactList.AddContact(ref MyContactList);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter A Valid Choice");
                        break;
                }
            }
            while (choice != 2);

        }
    }
}