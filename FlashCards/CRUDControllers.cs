using Microsoft.Data.SqlClient;
using System.Configuration;

namespace FlashCards
{
    public class CrudControllers
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        UserInputs input = new();

        public void GetAllComponents(string tableName)
        {
            if(CheckEmptyTable(tableName)) return;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var getTable = connection.CreateCommand();
            getTable.CommandText =
                $"SELECT * FROM {tableName}";
            if (tableName == "stacks")
            {
                SettingStackTable(getTable);
            }
            else
            {
                SettingCardTable(getTable, tableName);
            }
        }
        internal bool CheckEmptyTable(string table)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            var checkCmd = conn.CreateCommand();
            checkCmd.CommandText = $"SELECT 1 FROM dbo.{table}";
            int checkQuery = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (checkQuery == 0)
            {
                Console.WriteLine("No record in this table.");
                return true;
            }
            return false;
        }

        public void SettingStackTable(SqlCommand query)
        {
            BuildingTable table = new();
            List<StacksManagement> tableData = new();
            try
            {
                SqlDataReader reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SettingCardTable(SqlCommand query, string tableName)
        {
            BuildingTable table = new();
            List<CardsManagement> tableData = new();
            try
            {
                SqlDataReader reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tableData.Add(
                            new CardsManagement
                            {
                                Id = reader.GetInt32(0),
                                CardFront = reader.GetString(1),
                                CardBack = reader.GetString(2),
                            }
                            );
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
                table.MakingCardTable(tableData, tableName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Update(string tableName, int recordId)
        {
            GetAllComponents("stacks");
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            
            var queryChangeTableName = conn.CreateCommand();

            var checkCmd = conn.CreateCommand();
            checkCmd.CommandText = $"SELECT 1 FROM {tableName} WHERE Id = '{recordId}'";
            int rowCount = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (rowCount == 0)
            {
                Console.Write($"\n\nRecord with Id {recordId} does not exist. Press ENTER to try again.\n\n");
                Console.ReadLine();
                Console.Clear();                
                return;
            }
            if (tableName == "stacks")
            {
                UpdateStackTable(recordId);
            }
            else
            {
                //UpdateCard(tableName, recordId);
            }
        }
        public void UpdateStackTable(int recordId)
        {
            var oldStackEntryName = GetStackEntry(recordId);
            if (oldStackEntryName == null) return;

            var newStackEntryName = input.GetStringInputs("New stack name: ");

            using var conn = new SqlConnection(connectionString);
            conn.Open();          

            var changeCardTableName = conn.CreateCommand();
            changeCardTableName.CommandText =
                $"exec sp_rename '{oldStackEntryName}', '{newStackEntryName}'";

            var changeStackEntryName = conn.CreateCommand();
            changeStackEntryName.CommandText =
                $"UPDATE stacks SET stack_name = '{newStackEntryName}'";

            try
            {
                changeCardTableName.ExecuteScalar();
                changeStackEntryName.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return;
            }
        }
        public string GetStackEntry(int recordId)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            var getStackEntryName = conn.CreateCommand();
            getStackEntryName.CommandText = $"SELECT stack_name FROM stacks WHERE Id = '{recordId}'";
            try
            {
                return getStackEntryName.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " Press ENTER to continue.");
                Console.ReadLine();
                return null;
            }
        }
    }
}
