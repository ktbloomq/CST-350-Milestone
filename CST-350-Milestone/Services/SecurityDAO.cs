using System.Data.SqlClient;
using CST_350_Milestone.Models;

namespace CST_350_Milestone.Services
{
    public class SecurityDAO
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=milestone-cst-350;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool FindUserByNameAndPassword(UserModel user)
        {
            bool success = false;

            string sqlStatement = "SELECT * FROM dbo.users WHERE username = @username AND password = @password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50).Value = user.Username;
                command.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 50).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;
        }
        public bool RegisterUser(UserModel user)
        {
            bool success = false;
            string sqlStatement = "INSERT INTO dbo.users (firstName, lastName, sex, age, state, email, username, password) Values(@0, @1, @2, @3, @4, @5, @6, @7)";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);
                    command.Parameters.Add("@0", System.Data.SqlDbType.NVarChar, 50).Value = user.FirstName;
                    command.Parameters.Add("@1", System.Data.SqlDbType.NVarChar, 50).Value = user.LastName;
                    command.Parameters.Add("@2", System.Data.SqlDbType.Int).Value = user.Sex;
                    command.Parameters.Add("@3", System.Data.SqlDbType.Int).Value = user.Age;
                    command.Parameters.Add("@4", System.Data.SqlDbType.Int).Value = user.State;
                    command.Parameters.Add("@5", System.Data.SqlDbType.NVarChar, 50).Value = user.Email;
                    command.Parameters.Add("@6", System.Data.SqlDbType.NVarChar, 50).Value = user.Username;
                    command.Parameters.Add("@7", System.Data.SqlDbType.NVarChar, 50).Value = user.Password;
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;                    
        }
    }
}
