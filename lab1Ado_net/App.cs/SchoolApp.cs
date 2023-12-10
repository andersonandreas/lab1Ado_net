using lab1Ado_net.ConsolePrinter;
using lab1Ado_net.DatabaseHandler;
using lab1Ado_net.UserInteraction;

namespace lab1Ado_net.App.cs
{
    public class SchoolApp
    {
        // should be read from somewhere else in a more serious applcation like a json/web config files..
        // I removed the data source from the connection string, you need to fill in your own.
        private string _connectionString = "Data Source=********;Initial Catalog=SchoolChasAcademyDb;Integrated Security=True";

        public void Run()
        {

            var printer = new Printer();
            var dbHandler = new DbHandler(_connectionString, printer);
            var sqlHelper = new SqlSearch(dbHandler);
            var userMenuMethods = new UserMenuMethods(sqlHelper);
            var userMenu = new UserMenu(userMenuMethods);

            userMenu.StartMenu();

        }

    }
}
