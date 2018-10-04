using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDemo
{
    public class BooksDemo
    {
        private string[] colName = { "Book Title", "Auther", "Publisher", "Price" };
        private string[,] bookDetails = new string[2, 4];               // 2*4 Array to store book details

        static void Main(string[] args)
        {
            Console.WriteLine("Enter details of books :");
            BooksDemo bd = new BooksDemo();

            Console.WriteLine("1:Book Title \n2:Auther \n3:Publisher \n4:Price ");

            // for loop to read details of book in multidimensional array
            for (int i = 0; i < bd.bookDetails.GetLength(0); i++)
            {
                Console.WriteLine("\nEnter details of book {0} :", i + 1);
                for (int j = 0; j < bd.bookDetails.GetLength(1); j++)
                {
                    Console.Write(j + 1 + ":");
                    bd.bookDetails[i, j] = Console.ReadLine();
                }
            }
            // to print book details from  multidimensional array

            for (int i = 0; i < bd.colName.Length; i++)
            {
                Console.Write(bd.colName[i] + "\t");
            }

            for (int i = 0; i < bd.bookDetails.GetLength(0); i++)
            {
                for (int j = 0; j < bd.bookDetails.GetLength(1); j++)
                {
                    Console.Write(bd.bookDetails[i, j] + "\t\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
