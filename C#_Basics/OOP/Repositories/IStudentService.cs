namespace OOP.Repositories;

public interface IStudentService : IPersonService
{
    double CalculateGpa();
}