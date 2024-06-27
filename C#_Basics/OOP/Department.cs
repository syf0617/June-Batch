using OOP.Repositories;
namespace OOP;

public class Department(decimal budget) : IDepartmentService
{
    public Instructor Head = null!;
    public List<Course> Courses = [];
    private decimal _budget = budget;

    public void AssignHead(Instructor instructor)
    {
        Head = instructor;
        instructor.Department = this;
    }

    public decimal CalculateBudget(DateTime startDate, DateTime endDate)
    {
        var duration = endDate - startDate;
        return _budget * ((decimal)duration.TotalDays / 365);
    }
}