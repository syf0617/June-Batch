using OOP.Repositories;
namespace OOP;
public class Course(string name) : ICourseService
{
    public string Name = name;
    private List<Student> _students = [];

    public void EnrollStudent(Student student)
    {
        if (!_students.Contains(student))
        {
            _students.Add(student);
        }
    }
}