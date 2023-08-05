using System.Data.SqlClient;
using CST_350_Milestone.Models;
using Newtonsoft.Json;

namespace CST_350_Milestone.Services
{
	public class SavesDAO
	{
		string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=milestone-cst-350;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public List<object> getAll()
		{
			string sqlStatement = "SELECT * FROM dbo.saves";
			List<object> objects = new List<object>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(sqlStatement, connection);

				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						IDictionary<string, object> record = new Dictionary<string, object>();
						for (int i = 0; i < reader.FieldCount; i++)
						{
							record.Add(reader.GetName(i), reader[i]);
						}
						objects.Add(record);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return objects;
		}
		public string getOne(int id)
		{
			string gameState = null;

			string sqlStatement = "SELECT game FROM dbo.saves where id = @id";
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(sqlStatement, connection);

				command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					if (reader.Read())
					{
						// Console.WriteLine("has rows");
						gameState = (string)reader[0];
						Console.WriteLine(gameState);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return gameState;
		}
		public bool save(int userId, string gameState)
		{
			bool success = false;
			string sqlStatement = "INSERT INTO dbo.saves (userId, game) Values(@0, @1)";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					SqlCommand command = new SqlCommand(sqlStatement, connection);
					command.Parameters.Add("@0", System.Data.SqlDbType.Int).Value = userId;
					command.Parameters.Add("@1", System.Data.SqlDbType.NVarChar).Value = gameState;
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
