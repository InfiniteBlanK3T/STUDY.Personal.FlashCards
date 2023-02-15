using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Reflection.PortableExecutable;

namespace FlashCards
{
    public class CRUDControllers
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        public void GetAllComponents(string tableName)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var getTable = connection.CreateCommand();
            getTable.CommandText =
                $"SELECT * FROM {tableName} ";
            SetUpTable(tableName, getTable);
        }

        public void SetUpTable(string tableName,SqlCommand query)
        {
            BuildingTable table = new BuildingTable();
            List<object> tableComponent = new List<object>();

            try
            {
                SqlDataReader reader = query.ExecuteReader();                

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        object tableType = new();
                        if (tableName == "stacks")
                        {
                            tableType = new StackSession
                            {
                                StackId = reader.GetInt32(0),
                                StackName = reader.GetString(1)
                            };
                            
                        }
                        else
                        {
                            tableType = new CardSession
                            {
                                CardId = reader.GetInt32(0),
                                CardFront = reader.GetString(1),
                                CardBack = reader.GetString(2)
                            };
                            tableComponent.Add(tableType);
                        }
                        tableComponent.Add(tableType);
                    }
                }
                table.MakingTable(tableComponent, tableName);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
