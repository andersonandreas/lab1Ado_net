using System.Data.SqlClient;

namespace lab1Ado_net.ConsolePrinter
{
    public interface IPrinter
    {
        void PrintFromDb(SqlDataReader reader);
    }
}