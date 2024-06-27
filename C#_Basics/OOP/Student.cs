using OOP.Repositories;
namespace OOP;

public class Student(DateTime birthDate, decimal initialSalary, List<string> initialAddresses)
    : Person(birthDate, initialSalary, initialAddresses), IStudentService
{
    private Dictionary<Course, char> _courseGrades = new();

    public void EnrollInCourse(Course course)
    {
        if (_courseGrades.TryAdd(course, 'F'))
        {
            course.EnrollStudent(this);
        }
    }

    public void RecordGrade(Course course, char grade)
    {
        if (_courseGrades.ContainsKey(course))
        {
            _courseGrades[course] = grade;
        }
    }

    public double CalculateGpa()
    {
        if (_courseGrades.Count == 0) return 0;
        var totalPoints = _courseGrades.Values.Sum(GradeToPoint);
        return totalPoints / _courseGrades.Count;
    }

    private static double GradeToPoint(char grade)
    {
        return grade switch
        {
            'A' => 4.0,
            'B' => 3.0,
            'C' => 2.0,
            'D' => 1.0,
            'F' => 0.0,
            _ => 0.0
        };
    }
}