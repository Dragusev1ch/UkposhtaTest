using DALUkrposhtaTest.Entity;
using System.Data.SqlClient;

namespace DALUkrposhtaTest.DbService.DataAccess;

public class PositionDataAccess
{
    private readonly string _connectionString;
    public PositionDataAccess(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Add a new position
    public void AddPosition(Position position)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            const string query = @"INSERT INTO Positions (PositionID, PositionName) 
                                   VALUES (@PositionID, @PositionName)";
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PositionID", position.PositionID);
            command.Parameters.AddWithValue("@PositionName", position.PositionName);

            command.ExecuteNonQuery();
        }
    }

    // Get a position by ID
    public Position GetPosition(int positionId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            const string query = "SELECT * FROM Positions WHERE PositionID = @PositionID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PositionID", positionId);

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Position
                    {
                        PositionID = (int)reader["PositionID"],
                        PositionName = reader["PositionName"].ToString()
                    };
                }
                else
                {
                    return null;
                }
            }
        }
    }

    // Update an existing position
    public void UpdatePosition(Position position)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            const string query = @"UPDATE Positions 
                                   SET PositionName = @PositionName
                                   WHERE PositionID = @PositionID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PositionID", position.PositionID);
            command.Parameters.AddWithValue("@PositionName", position.PositionName);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Delete a position
    public void DeletePosition(int positionId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            const string query = "DELETE FROM Positions WHERE PositionID = @PositionID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PositionID", positionId);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}