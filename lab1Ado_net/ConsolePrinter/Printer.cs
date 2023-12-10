using System.Data.SqlClient;

namespace lab1Ado_net.ConsolePrinter
{
    public class Printer : IPrinter
    {

        public void PrintFromDb(SqlDataReader reader)
        {

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i).ToString();
                object? columnValue = reader.IsDBNull(i) ? "" : reader.GetValue(i).ToString();

                Console.WriteLine($"{columnName}: {columnValue}");

            }

            Console.WriteLine("-------------------------------------------");
        }



    }
}
