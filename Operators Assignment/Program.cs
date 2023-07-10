using System;

class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Constructor for initializing Employee object
    public Employee(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    // Overload the "==" operator to compare two Employee objects by their Id
    public static bool operator ==(Employee employee1, Employee employee2)
    {
        // Check if the references point to the same object
        if (ReferenceEquals(employee1, employee2))
        {
            return true;
        }

        // Check if either of the references is null
        if (ReferenceEquals(employee1, null) || ReferenceEquals(employee2, null))
        {
            return false;
        }

        // Compare the Id values of the two Employee objects
        return employee1.Id == employee2.Id;
    }

    // Overload the "!=" operator to compare two Employee objects by their Id
    public static bool operator !=(Employee employee1, Employee employee2)
    {
        // Use the negation of the "==" operator to implement "!="
        return !(employee1 == employee2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create two Employee objects
        Employee employee1 = new Employee(1, "John", "Doe");
        Employee employee2 = new Employee(2, "Jane", "Smith");

        // Compare the Employee objects using the overloaded operators and display the results
        Console.WriteLine($"Are employee1 and employee2 equal? {employee1 == employee2}");
        Console.WriteLine($"Are employee1 and employee1 equal? {employee1 == employee1}");
    }
}
