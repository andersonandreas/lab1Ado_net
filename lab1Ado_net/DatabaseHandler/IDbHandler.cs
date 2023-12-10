namespace lab1Ado_net.DatabaseHandler
{
    public interface IDbHandler
    {
        void AddToDatabase(string query);
        void RunQueryAndPrint(string query);
    }
}