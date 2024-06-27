namespace OOP.Repositories;

public interface IInstructorService : IPersonService
{
    int CalculateExperience();
    void AssignGrade(Student student, Course course, char grade);
} 