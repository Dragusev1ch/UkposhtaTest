using DALUkrposhtaTest.DbService.DataAccess;
using DALUkrposhtaTest.Entity;

namespace APIUkrposhtaTest.Services;

public class EmployeeService
{
    private readonly EmployeeDataAccess _employeeDataAccess;

    public EmployeeService(EmployeeDataAccess employeeDataAccess)
    {
        _employeeDataAccess = employeeDataAccess;
    }

    public void AddEmployee(Employee employee)
    {
        _employeeDataAccess.AddEmployee(employee);
    }

    public Employee GetEmployee(int id)
    {
        return _employeeDataAccess.GetEmployee(id);
    }

    public List<Employee> List()
    {
        return _employeeDataAccess.GetEmployees();
    }
    public void UpdateEmployee(Employee employee)
    {
        _employeeDataAccess.UpdateEmployee(employee);
    }

    public void DeleteEmployee(int id)
    {
        _employeeDataAccess.DeleteEmployee(id);
    }
}