using OOP.Repositories;
namespace OOP;

public abstract class Person(DateTime birthDate, decimal initialSalary, List<string> initialAddresses)
    : IPersonService
{
    private decimal _salary = initialSalary;
    private List<string> _addresses = [..initialAddresses];

    public int CalculateAge()
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        
        if (birthDate.Date > today.AddYears(-age)) age--;
        
        return age;
    }

    public virtual decimal CalculateSalary() => _salary >= 0 ? _salary : throw new ArgumentException("Salary cannot be negative");

    public List<string> GetAddresses() => _addresses;
}