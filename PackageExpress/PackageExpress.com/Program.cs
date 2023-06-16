using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageExpress.com
{
    class program
    {
        static void Main(string[] args)

        {
            {
                Console.WriteLine("Welcome to OMAR's Package Express.Please follow the instructions below.");
                Console.WriteLine("Please prompted for the package weight.");
            }
            //introduction lines to begin with


            Console.WriteLine("Please enter the package weight:");
            int weight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("package weight is: " + weight);
            // this is to ask about the package weight


            if (weight > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            }
                else
            
                {
                Console.WriteLine("Weight is acceptable, Thank you!.");
                }
            //if package weight is more than 50 then it will not be acceptable

            {
                Console.WriteLine("Please enter the package width:");
                int width = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("package width is: " + width);

                Console.WriteLine("Please enter the package height:");
                int height = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("package height is: " + height);

                Console.WriteLine("Please enter the package lenght:");
                int length = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("package lenght is: " + length);

                int product = height * width * length * weight / 100;
                Console.WriteLine("Your estimated total for shipping this package is:");
                Console.WriteLine(product);
                Console.WriteLine("Thank you");
           //this is to record the package weight, width, lenght & height 

                if ((length * width * height) > 50)
                {
                    Console.WriteLine("Package too big to be shipped via Package Express.");
                }
           //if package dimention is more than 50 the package is not acceptale

                else
                {
                    Console.WriteLine("Package is acceptable, Thank you!.");
                }
            }   






        }




    }



}

