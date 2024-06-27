namespace OOP.Repositories;
    
using System;

public interface IDepartmentService
{
    void AssignHead(Instructor instructor);
    decimal CalculateBudget(DateTime startDate, DateTime endDate);
}