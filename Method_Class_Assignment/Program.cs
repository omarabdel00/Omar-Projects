

namespace Method_Class_Assignment
{
    class MathOperation1
    {
        //Create a method that takes two integers as parameters
        //Make one parameter optional by providin a default value
        public int mathOperation(int i, int j = 1)
        {
            //perform multiplication on integers and return the result
            int result = i * j;
            return result;
        }
      

    }

}




namespace Method_Class_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate mathoperation1 class
           MathOperation1 mathOp = new MathOperation1();
            //Ask the user to provide first parameter
            Console.WriteLine("Enter an integer");
            int num1 = Convert.ToInt32(Console.ReadLine());
            //Ask the user to provide a second parameter or press enter
            Console.WriteLine("enter as second integer, Or just press enter: ");
            try
            {
                //call method with 2 parameters if both parameters are provided 
                int num2 = Convert.ToInt32(Console.ReadLine());
                int results = mathOp.mathOperation(num1, num2);
                Console.WriteLine(num1 + " x " + num2 + " = " + results);
            }
            catch
            {
                //call method with one parameter if only one is provided
                int results = mathOp.mathOperation(num1);
                Console.WriteLine(num1 + " x Default 1 = " + results);

            }
             Console.ReadLine();


            }

    }

}
