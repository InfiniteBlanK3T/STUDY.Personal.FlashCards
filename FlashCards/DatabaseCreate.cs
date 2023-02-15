using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;

namespace FlashCards
{
    public class DatabaseCreate
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        private string _cardTableName;

        public DatabaseCreate(string tableName)
        {
            _cardTableName= tableName;
            CreateTables();
        }

        public string CardTableName
        {
            get { return _cardTableName; }
            set { _cardTableName = value; }
        }
        public void CreateTables()
        {            
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var makeStackTable = connection.CreateCommand();
            makeStackTable.CommandText =
                $@"IF NOT EXISTS (SELECT * FROM sys.tables t
                JOIN sys.schemas s ON (t.schema_id = s.schema_id) 
                WHERE s.name = 'dbo' AND t.name = 'stacks')
                CREATE TABLE stacks (
                stack_Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
                stack_name VARCHAR(55)
                );";

            var insertEntryToStackToTable = connection.CreateCommand();
            insertEntryToStackToTable.CommandText =
                $@"INSERT INTO stacks (stack_name) VALUES
                ('{CardTableName}');";

            var makeCardTable = connection.CreateCommand();
            makeCardTable.CommandText =
                $@"IF NOT EXISTS (SELECT * FROM sys.tables t
                JOIN sys.schemas s on (t.schema_id = s.schema_id)
                WHERE s.name = 'dbo' AND t.name = '{CardTableName}')
                CREATE TABLE {CardTableName} (
                card_Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
                card_front VARCHAR(255),
                card_back VARCHAR(255)
                );";
            try
            {
                makeStackTable.ExecuteNonQuery();
                makeCardTable.ExecuteNonQuery();
                insertEntryToStackToTable.ExecuteNonQuery();                               
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }            
        }
    }
}
