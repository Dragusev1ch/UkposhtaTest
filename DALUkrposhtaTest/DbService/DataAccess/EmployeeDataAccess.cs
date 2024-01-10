using System.Data.SqlClient;
using DALUkrposhtaTest.Entity;
using DALUkrposhtaTest.Mapper;

namespace DALUkrposhtaTest.DbService.DataAccess;

public class EmployeeDataAccess
{
    private readonly string _connectionString;
    public EmployeeDataAccess(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddEmployee(Employee employee)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            const string query = @"INSERT INTO Employees (EmployeeID, DepartmentID, PositionID, CompanyID, LastName, FirstName, MiddleName, Address, Phone, BirthDate, HireDate, Salary) 
                                VALUES (@EmployeeID, @DepartmentID, @PositionID, @CompanyID, @LastName, @FirstName, @MiddleName, @Address, @Phone, @BirthDate, @HireDate, @Salary)";
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
            command.Parameters.AddWithValue("@DepartmentID", employee.DepartmentID);
            command.Parameters.AddWithValue("@PositionID", employee.PositionID);
            command.Parameters.AddWithValue("@CompanyID", employee.CompanyID);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@MiddleName", employee.MiddleName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Address", employee.Address ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Phone", employee.Phone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
            command.Parameters.AddWithValue("@HireDate", employee.HireDate);
            command.Parameters.AddWithValue("@Salary", employee.Salary);

            command.ExecuteNonQuery();
        }
    }

    public Employee GetEmployee(int employeeId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            const string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeID", employeeId);

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Employee
                    {
                        EmployeeID = (int)reader["EmployeeID"],
                        DepartmentID = (int)reader["DepartmentID"],
                        PositionID = (int)reader["PositionID"],
                        CompanyID = (int)reader["CompanyID"],
                        LastName = reader["LastName"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        MiddleName = reader["MiddleName"].ToString(),
                        Address = reader["Address"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        BirthDate = (DateTime)reader["BirthDate"],
                        HireDate = (DateTime)reader["HireDate"],
                        Salary = (decimal)reader["Salary"]
                    };
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public List<Employee> GetEmployees()
    {
        var employees = new List<Employee>();
        string sql = "SELECT * FROM Employees";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var employee = EmployeeMap.Map(reader);
                    employees.Add(employee);
                }
                reader.Close();
            }
        
        return employees;
    }

    // Update (Оновлення даних співробітника)
    public void UpdateEmployee(Employee employee)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            const string query = @"UPDATE Employees 
                                    SET DepartmentID = @DepartmentID, PositionID = @PositionID, CompanyID = @CompanyID, LastName = @LastName, 
                                        FirstName = @FirstName, MiddleName = @MiddleName, Address = @Address, Phone = @Phone, 
                                        BirthDate = @BirthDate, HireDate = @HireDate, Salary = @Salary 
                                    WHERE EmployeeID = @EmployeeID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
            command.Parameters.AddWithValue("@DepartmentID", employee.DepartmentID);
            command.Parameters.AddWithValue("@PositionID", employee.PositionID);
            command.Parameters.AddWithValue("@CompanyID", employee.CompanyID);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@MiddleName", employee.MiddleName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Address", employee.Address ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Phone", employee.Phone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
            command.Parameters.AddWithValue("@HireDate", employee.HireDate);
            command.Parameters.AddWithValue("@Salary", employee.Salary);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void DeleteEmployee(int employeeId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            const string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeID", employeeId);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}