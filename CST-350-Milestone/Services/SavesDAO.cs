using System.Data.SqlClient;
using CST_350_Milestone.Models;
using Newtonsoft.Json;

namespace CST_350_Milestone.Services
{
	public class SavesDAO
	{
		string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=milestone-cst-350;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		// incomplete

		public List<SavesDTO> GetAll()
		{
			List<SavesDTO> savedGames = new List<SavesDTO>();

			string sqlStatement = "SELECT * FROM dbo.saves";
			using (SqlConnection connection = new SqlConnection(connectionString)) 
			{
				SqlCommand command = new SqlCommand(sqlStatement, connection);

				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						savedGames.Add(new SavesDTO((int)reader[0], (int)reader[1], (string)reader[2], (DateTime)reader[3]));
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				};
			}
			return savedGames;
		}

		public SavesDTO getOne(int id)
		{
			Console.WriteLine("DAO: " + id);
			SavesDTO gameState = null;

			string sqlStatement = "SELECT * FROM dbo.saves where id = @id";
			using (
				SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(sqlStatement, connection);

				command.Parameters.AddWithValue("@id", id);

				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						// Console.WriteLine("has rows");
						gameState = new SavesDTO((int)reader[0], (int)reader[1], (string)reader[2], (DateTime)reader[3]);
						Console.WriteLine(gameState);
					}
				}
				catch (SqlException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return gameState;
		}
		public bool save(int userId, string gameState)
		{
			bool success = false;
			DateTime dateTime = DateTime.Now;
			string sqlStatement = "INSERT INTO dbo.saves (userId, game, date_saved) Values(@0, @1, @2)";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					SqlCommand command = new SqlCommand(sqlStatement, connection);
					command.Parameters.Add("@0", System.Data.SqlDbType.Int).Value = userId;
					command.Parameters.Add("@1", System.Data.SqlDbType.NVarChar).Value = gameState;
					command.Parameters.Add("@2", System.Data.SqlDbType.DateTime).Value = dateTime;
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

		public bool DeleteOne(int id)
		{
            string sqlStatement = "DELETE FROM dbo.saves WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                
				command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    
					command.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
					return false;
                }
            }
			return true;
        } 
	}
}
