using System;

// Step 1: Create the IQuittable interface
interface IQuittable
{
    void Quit();
}

// Step 2: Inherit the IQuittable interface in the Employee class
class Employee : IQuittable
{
    public string Name { get; set; }

    public Employee(string name)
    {
        Name = name;
    }

    // Implement the Quit method defined in the IQuittable interface
    public void Quit()
    {
        Console.WriteLine($"Employee {Name} is quitting...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Step 3: Use polymorphism to create an object of type IQuittable
        // and call the Quit() method on it
        IQuittable quittableEmployee = new Employee("John Doe");
        quittableEmployee.Quit();
    }
}
