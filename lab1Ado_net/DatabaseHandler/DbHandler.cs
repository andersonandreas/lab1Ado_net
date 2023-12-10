using lab1Ado_net.ConsolePrinter;
using System.Data.Common;
using System.Data.SqlClient;

namespace lab1Ado_net.DatabaseHandler
{
    public class DbHandler : IDbHandler
    {


        private readonly string _connectionString;
        private readonly IPrinter _print;

        public DbHandler(string connectionString, IPrinter print)
        {
            _connectionString = connectionString;
            _print = print;
        }


        public void RunQueryAndPrint(string query)
        {

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        RunAndPrintResult(command);
                    }
                }

            }
            catch (DbException e)
            {
                Console.WriteLine(
                    "An error occurred when tried to read from the database: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }



        public void AddToDatabase(string query)
        {

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(
                    "An error occurred when adding new data to database: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }



        private void RunAndPrintResult(SqlCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    _print.PrintFromDb(reader);
                }
            }
        }



    }
}
