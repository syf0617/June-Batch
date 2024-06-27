namespace OOP.Repositories;
using System.Collections.Generic;

public interface IPersonService
{
    decimal CalculateSalary();
    int CalculateAge();
    List<string> GetAddresses();
}