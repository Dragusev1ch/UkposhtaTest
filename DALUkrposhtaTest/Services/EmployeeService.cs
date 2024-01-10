using DALUkrposhtaTest.DbService.DataAccess;
using DALUkrposhtaTest.Entity;
using System.Text;

namespace DALUkrposhtaTest.Services;

public class EmployeeService 
{
    private EmployeeDataAccess _dataAccess;

    public EmployeeService(EmployeeDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public List<Employee> GetEmployeesSorted(string sortBy, bool ascending = true)
    {
        var employees = _dataAccess.GetEmployees();

        return sortBy.ToLower() switch
        {
            "position" => ascending
                ? employees.OrderBy(e => e.PositionID).ToList()
                : employees.OrderByDescending(e => e.PositionID).ToList(),
            "department" => ascending
                ? employees.OrderBy(e => e.DepartmentID).ToList()
                : employees.OrderByDescending(e => e.DepartmentID).ToList(),
            "lastname" => ascending
                ? employees.OrderBy(e => e.LastName).ToList()
                : employees.OrderByDescending(e => e.LastName).ToList(),
            "birthdate" => ascending
                ? employees.OrderBy(e => e.BirthDate).ToList()
                : employees.OrderByDescending(e => e.BirthDate).ToList(),
            "salary" => ascending
                ? employees.OrderBy(e => e.Salary).ToList()
                : employees.OrderByDescending(e => e.Salary).ToList(),
            _ => throw new ArgumentException("Invalid sort parameter")
        };
    }

    public void ExportEmployeesToTxtFile(string sortBy, bool ascending = true, string filePath = "employees.txt")
    {
        var employees = GetEmployeesSorted(sortBy, ascending);

        StringBuilder sb = new StringBuilder();
        foreach (var employee in employees)
        {
            sb.AppendLine($"ID: {employee.EmployeeID}, Last Name: {employee.LastName}, First Name: {employee.FirstName}, Position ID: {employee.PositionID}, Department ID: {employee.DepartmentID}, Birth Date: {employee.BirthDate}, Salary: {employee.Salary}");
        }

        File.WriteAllText(filePath, sb.ToString());
    }
}