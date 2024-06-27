namespace OOP;
using System;

class Program
{
    public static void Main()
    {
        var course = new Course("Database");
        var department = new Department(1000000);
        var student = new Student(new DateTime(2000, 1, 1), 0, ["123 Main St"]);
        var instructor = new Instructor( new DateTime(1984, 7, 04), 50000, ["456 Sub Dr", "789 Lef Rd"], department, new DateTime(2010, 9, 1));
        
        department.AssignHead(instructor);
        student.EnrollInCourse(course);
        instructor.AssignGrade(student, course, 'A');

        Console.WriteLine($"Student Age: {student.CalculateAge():0}");
        Console.WriteLine($"Instructor Age: {instructor.CalculateAge():0}");
        Console.WriteLine($"Student Addresses: {string.Join(", ", student.GetAddresses())}");
        Console.WriteLine($"Instructor Addresses: {string.Join(", ", instructor.GetAddresses())}");
        Console.WriteLine($"Student GPA: {student.CalculateGpa():0.00}");
        Console.WriteLine($"Instructor Experience: {instructor.CalculateExperience()} years");
        Console.WriteLine($"Instructor Salary: ${instructor.CalculateSalary():0.00}");
        Console.WriteLine($"Department Budget for a Year: ${department.CalculateBudget(new DateTime(2023, 1, 1), new DateTime(2023, 12, 31)):0.00}");
    }
}