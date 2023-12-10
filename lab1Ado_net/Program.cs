using lab1Ado_net.App.cs;

namespace lab1Ado_net
{
    internal class Program
    {
        // I know that i can use SQL Parameters and I should also validate the user input so that matches to database structure etc.

        static void Main(string[] args)
        {
            try
            {

                var app = new SchoolApp();
                app.Run();

            }
            catch (Exception e)
            {

                Console.WriteLine($"An Error has occurred and the app is closing: {e.Message}");
            }


        }
    }
}