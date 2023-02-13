using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;

namespace Flashcards;

class Program
{
    static void Main()
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        string connectionString = "Data Source=(LocalDb)\\PersonalProjectDB;Initial Catalog=FlashcardsDB";
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var tableCmd = connection.CreateCommand();
        tableCmd.CommandText =
            $@"IF NOT EXISTS (SELECT * FROM sys.tables t
            JOIN sys.schemas s ON (t.schema_id = s.schema_id) 
            WHERE s.name = 'dbo' AND t.name = 't1')
            CREATE TABLE TestTABLE (
            Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
            name VARCHAR(55)
            );";
        try
        {
            tableCmd.ExecuteNonQuery();
            Console.WriteLine("Succeed!");
            Console.ReadLine();
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }

        Console.ReadLine();
    }
}