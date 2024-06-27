using OOP.Repositories;
namespace OOP;

public class Instructor(
    DateTime birthDate,
    decimal initialSalary,
    List<string> initialAddresses,
    Department department,
    DateTime joinDate)
    : Person(birthDate, initialSalary, initialAddresses), IInstructorService
{
    public DateTime JoinDate = joinDate;
    public Department Department = department;

    public int CalculateExperience() => DateTime.Now.Year - JoinDate.Year;

    public override decimal CalculateSalary()
    {
        var yearsExperience = CalculateExperience();
        var bonus = yearsExperience * 1000m;
        return base.CalculateSalary() + bonus;
    }
    
    public void AssignGrade(Student student, Course course, char grade)
    {
        student.RecordGrade(course, grade);
    }
}