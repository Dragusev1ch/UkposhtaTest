using DALUkrposhtaTest.Entity;
using System.Data.SqlClient;

namespace DALUkrposhtaTest.DbService.DataAccess;

public class CompanyInfoDataAccess
{
    private readonly string _connectionString;
    public CompanyInfoDataAccess(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Add a new company
    public void AddCompany(CompanyInfo company)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            const string query = @"INSERT INTO CompanyInfo (CompanyID, CompanyName, Address, Phone) 
                                   VALUES (@CompanyID, @CompanyName, @Address, @Phone)";
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CompanyID", company.CompanyID);
            command.Parameters.AddWithValue("@CompanyName", company.CompanyName);
            command.Parameters.AddWithValue("@Address", company.Address);
            command.Parameters.AddWithValue("@Phone", company.Phone);

            command.ExecuteNonQuery();
        }
    }

    // Get a company by ID
    public CompanyInfo GetCompany(int companyId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            const string query = "SELECT * FROM CompanyInfo WHERE CompanyID = @CompanyID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CompanyID", companyId);

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new CompanyInfo
                    {
                        CompanyID = (int)reader["CompanyID"],
                        CompanyName = reader["CompanyName"].ToString(),
                        Address = reader["Address"].ToString(),
                        Phone = reader["Phone"].ToString()
                    };
                }
                else
                {
                    return null;
                }
            }
        }
    }

    // Update an existing company
    public void UpdateCompany(CompanyInfo company)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            const string query = @"UPDATE CompanyInfo
                                   SET CompanyName = @CompanyName, Address = @Address, Phone = @Phone
                                   WHERE CompanyID = @CompanyID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CompanyID", company.CompanyID);
            command.Parameters.AddWithValue("@CompanyName", company.CompanyName);
            command.Parameters.AddWithValue("@Address", company.Address);
            command.Parameters.AddWithValue("@Phone", company.Phone);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Delete a company
    public void DeleteCompany(int companyId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            const string query = "DELETE FROM CompanyInfo WHERE CompanyID = @CompanyID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CompanyID", companyId);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}