using DALUkrposhtaTest.Entity;
using System.Data.SqlClient;

namespace DALUkrposhtaTest.DbService.DataAccess;

public class DepartmentDataAccess
{
    private readonly string _connectionString;
    public DepartmentDataAccess(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Add a new department
    public void AddDepartment(Department department)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            const string query = @"INSERT INTO Departments (DepartmentID, DepartmentName) 
                                   VALUES (@DepartmentID, @DepartmentName)";
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
            command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);

            command.ExecuteNonQuery();
        }
    }

    // Get a department by ID
    public Department GetDepartment(int departmentId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            const string query = "SELECT * FROM Departments WHERE DepartmentID = @DepartmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DepartmentID", departmentId);

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Department
                    {
                        DepartmentID = (int)reader["DepartmentID"],
                        DepartmentName = reader["DepartmentName"].ToString()
                    };
                }
                else
                {
                    return null;
                }
            }
        }
    }

    // Update an existing department
    public void UpdateDepartment(Department department)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            const string query = @"UPDATE Departments 
                                   SET DepartmentName = @DepartmentName
                                   WHERE DepartmentID = @DepartmentID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
            command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Delete a department
    public void DeleteDepartment(int departmentId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            const string query = "DELETE FROM Departments WHERE DepartmentID = @DepartmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DepartmentID", departmentId);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}