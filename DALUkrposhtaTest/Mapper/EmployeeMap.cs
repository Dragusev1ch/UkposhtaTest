using System.Data.SqlClient;
using DALUkrposhtaTest.Entity;

namespace DALUkrposhtaTest.Mapper;

public class EmployeeMap
{
    public static Employee Map(SqlDataReader reader)
    {
        var employee = new Employee();

        employee.EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID"));
        employee.DepartmentID = reader.GetInt32(reader.GetOrdinal("DepartmentID"));
        employee.PositionID = reader.GetInt32(reader.GetOrdinal("PositionID"));
        employee.CompanyID = reader.GetInt32(reader.GetOrdinal("CompanyID"));
        employee.LastName = reader.GetString(reader.GetOrdinal("LastName"));
        employee.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
        employee.MiddleName = reader.GetString(reader.GetOrdinal("MiddleName"));
        employee.Address = reader.GetString(reader.GetOrdinal("Address"));
        employee.Phone = reader.GetString(reader.GetOrdinal("Phone"));
        employee.BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));
        employee.HireDate = reader.GetDateTime(reader.GetOrdinal("HireDate"));
        employee.Salary = reader.GetDecimal(reader.GetOrdinal("Salary"));

        return employee;
    }
}