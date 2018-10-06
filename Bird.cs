using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debug_BirdClass
{
    public class Bird                  //PUBLIC-Elements defined in a namespace cannot be explicitly declared as private, protected or protected internal 
    {
        public string Name;
        public double Maxheight;

        public Bird()  //Default Constructor
        {
            this.Name = "Mountain Eagle";           // String " "
            this.Maxheight = 500;                 // Maxheight has data type double so cannot write in ""
        }

        public Bird(string birdname, double max_ht) //Overloaded Constructor
        {
            //this.Name = "Another Bird";               // it is parametarized constructor so values should be captured
            this.Name = birdname;
            this.Maxheight = max_ht;                  // "null" cannot be asigned to double
        }

        public void fly()
        {
            Console.WriteLine(this.Name + " is flying at altitude" + this.Maxheight);      // variables were quoted in "" as a statement
        }

        public void fly(double AtHeight)                    // height is with data type double at the function call
        {
            if (AtHeight <= this.Maxheight)
                Console.WriteLine(this.Name + " flying at " + AtHeight.ToString());
            else if (AtHeight > this.Maxheight)                                                                   // was spelled incorrectly "else if" requires a condition
                Console.WriteLine(this.Name + " cannot fly at this height");
        }
        static void Main(string[] args)
        {
            Bird b = new Bird("Eagle", double.Parse("200"));
            b.fly();
            b.fly(double.Parse("300"));

            Console.ReadKey();
        }
    }
}
