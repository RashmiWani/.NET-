using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Calalog
{
    class Car
    {
        public string Car_Maker { get; set; }
        public int Car_ModelNo { get; set; }
        public string Year { get; set; }
        public double SalePrice { get; set; }
        public Car()
        {
            this.Car_Maker = "";
            this.Car_ModelNo = 0;
            this.Year = "";
            this.SalePrice = 0.0;
        }
        public Car(string Car_Maker, int Car_ModelNo, string Year, double SalePrice)
        {
            this.Car_Maker = Car_Maker;
            this.Car_ModelNo = Car_ModelNo;
            this.Year = Year;
            this.SalePrice = SalePrice;
        }
        static void Main(string[] args)
        {
            int count = 0;
            int choice;

            Console.Write("Total Number of cars to be added catalog :\t");
            int total = Convert.ToInt32(Console.ReadLine());

            Car[] c = new Car[total];
            do
            {
                Console.WriteLine("\n\nEnter Your Choice :\n1:Add new Car\n2:Modify details of car\n3:Search car in catalog\n4:List all cars in catalog\n5:Delete a car from catalog\n6:Exit\n-");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:                 // 1:Add new Car
                        {
                            Console.WriteLine();
                            Console.Write("Enter Car Maker's name :\t");
                            string car_mkr = Console.ReadLine();

                            Console.Write("Enter Model Number of car :\t");
                            int modelNo = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Year of Manufacture :\t");
                            string year = Console.ReadLine();

                            Console.Write("Enter Sale Price :\t");
                            double salesPrice = Convert.ToDouble(Console.ReadLine());

                            c[count] = new Car(car_mkr, modelNo, year, salesPrice);
                            count++;

                            break;
                        }
                    case 2:                 //2:Modify details of car
                        {
                            Console.Write("Enter Model Number of car :\t");
                            int modelNo_temp = Convert.ToInt32(Console.ReadLine());
                            int a = 0;

                            for (int i = 0; i < count; i++)
                            {
                                a++;
                                if (modelNo_temp == c[i].Car_ModelNo)
                                {
                                    Console.Write("Enter Car Maker's name :\t");
                                    c[i].Car_Maker = Console.ReadLine();

                                    Console.Write("Enter Year of Manufacture :\t");
                                    c[i].Year = Console.ReadLine();

                                    Console.Write("Enter Sale Price :\t");
                                    c[i].SalePrice = Convert.ToDouble(Console.ReadLine());
                                }
                            }
                            if (a == 0)
                            {
                                Console.WriteLine("Please Check Model Number.");
                            }
                            break;
                        }
                    case 3:                 //3:Search car in catalog
                        {
                            Console.Write("Enter Model Number of car :\t");
                            int modelNo_temp = Convert.ToInt32(Console.ReadLine());
                            int a = 0;
                            Console.WriteLine("Model Number\t Car Maker \t Year \t Sales Price");
                            for (int i = 0; i < count; i++)
                            {
                                if (modelNo_temp == c[i].Car_ModelNo)
                                {
                                    a++;

                                    Console.WriteLine(c[i].Car_ModelNo + "\t\t" + c[i].Car_Maker + "\t\t" + c[i].Year + "\t\t" + c[i].SalePrice);
                                }
                            }
                            if (a == 0)
                            {
                                Console.WriteLine("Please Check Model Number.");
                            }
                            break;
                        }
                    case 4:                 //4:List all cars in catalog
                        {
                            Console.WriteLine("\n\nModel Number\t Car Maker \t Year \t Sales Price");
                            for (int i = 0; i < count; i++)
                            {
                                Console.WriteLine(c[i].Car_ModelNo + "\t\t" + c[i].Car_Maker + "\t\t" + c[i].Year + "\t\t" + c[i].SalePrice + "\n");
                            }
                            break;
                        }
                    case 5:                 //5: Delete cars in catalog
                        {
                            Console.Write("Enter Model Number of car :\t");
                            int modelNo_temp = Convert.ToInt32(Console.ReadLine());
                            int a = 0;

                            Console.WriteLine("\n\nModel Number\t Car Maker \t Year \t Sales Price");
                            for (int i = 0; i < count; i++)
                            {
                                if (modelNo_temp == c[i].Car_ModelNo)
                                {
                                    Console.WriteLine(c[i].Car_ModelNo + "\t\t" + c[i].Car_Maker + "\t\t" + c[i].Year + "\t\t" + c[i].SalePrice + "\n");
                                    c[i] = null;
                                    for (int j = i + 1; j < count; j++)
                                    {
                                        c[i] = c[j];
                                        i++;
                                    }
                                    a++;
                                    count--;
                                    break;
                                }
                            }
                            if (a == 0)
                            {
                                Console.WriteLine("Please Check Model Number.");
                            }
                            break;
                        }
                    case 6:                 //6:Exit
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Please Enter a valid choice.");
                            break;
                        }
                }
            } while (choice != 6);
        }
    }
}
