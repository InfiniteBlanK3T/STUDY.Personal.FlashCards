using Microsoft.Data.SqlClient;
using System.Configuration;

namespace FlashCards
{
    public class CrudControllers
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        public void GetAllComponents(string tableName)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var getTable = connection.CreateCommand();
            getTable.CommandText =
                $"SELECT * FROM {tableName}";
            SettingStackTable(getTable);
        }

        public void SettingStackTable(SqlCommand query)
        {
            BuildingTable table = new();
            List<StacksManagement> tableData = new();
            try
            {
                SqlDataReader reader = query.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        tableData.Add(
                            new StacksManagement
                            {
                                Id = reader.GetInt32(0),
                                StackName = reader.GetString(1),
                            }
                            );
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
                table.MakingStackTable(tableData);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
