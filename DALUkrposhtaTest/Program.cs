using System.Data.SqlClient;
using DALUkrposhtaTest.DbService.DataAccess;
using DALUkrposhtaTest.Pl;

class Program
{
    static void Main()
    {
        try
        {
            string connectionString = "Server=NAZARUTO\\SQLEXPRESS; Database = UkrposhtaTest; Integrated Security = True; Trusted_Connection = SSPI; Encrypt = false; TrustServerCertificate = true"; 

            Menu mainMenu = new Menu(connectionString);
            mainMenu.ShowMainMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }


        //EmployeeDataAccess access = new EmployeeDataAccess("Server=NAZARUTO\\SQLEXPRESS; Database = UkrposhtaTest; Integrated Security = True; Trusted_Connection = SSPI; Encrypt = false; TrustServerCertificate = true");

        //access.GetEmployees();

        //string connectionString = "Server=NAZARUTO\\SQLEXPRESS; Database=UkrposhtaTest; Integrated Security=True; Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true";

        //using (SqlConnection connection = new SqlConnection(connectionString))
        //{
        //    connection.Open();

        //    string sql = "SELECT * FROM Employees";
        //    SqlCommand command = new SqlCommand(sql, connection);

        //    using (SqlDataReader reader = command.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            for (int i = 0; i < reader.FieldCount; i++)
        //            {
        //                Console.Write(reader[i].ToString() + " ");
        //            }
        //            Console.WriteLine();
        //        }
        //    }
        //}
    }
}