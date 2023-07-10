using System;
using System.Data.Entity;
namespace EF6CodeFirstDemo
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {

        }
        // Entities        
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var student = new Student() { StudentName = "Bill" };

                ctx.Students.Add(student);
                ctx.SaveChanges();
            }
            Console.WriteLine("Demo completed.");
            Console.ReadLine();
        }
    }
}