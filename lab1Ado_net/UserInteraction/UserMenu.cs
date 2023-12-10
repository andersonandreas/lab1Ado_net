namespace lab1Ado_net.UserInteraction
{
    public class UserMenu
    {

        private readonly IUserMenuMethods _menuMethods;

        public UserMenu(IUserMenuMethods menuMethods)
        {
            _menuMethods = menuMethods;
        }

        public void StartMenu()
        {
            bool exitMenu = false;

            while (!exitMenu)
            {
                _menuMethods.PrintUserChoice();
                string choice = _menuMethods.PromptAndReadUserInput("\nEnter choice");

                if (ValidateUserChoice(choice, out MenuChoice userChoice))
                {
                    switch (userChoice)
                    {
                        case MenuChoice.StudentSearch:
                            _menuMethods.InputForStudentSearch();
                            break;
                        case MenuChoice.GetStudentsInAClass:
                            _menuMethods.GetStudentsInAClass();
                            break;
                        case MenuChoice.AddEmployee:
                            _menuMethods.InputForAddEmp();
                            break;
                        case MenuChoice.AllEmployeesByRole:
                            _menuMethods.AllEmployeesOurByRole();
                            break;
                        case MenuChoice.AllGradeRecentMonth:
                            _menuMethods.AllGradeRecentMonth();
                            break;
                        case MenuChoice.AverageGradeForAllCourses:
                            _menuMethods.AverageGradeForAllCourses();
                            break;
                        case MenuChoice.AddStudent:
                            _menuMethods.InputForAddStudent();
                            break;
                        case MenuChoice.Exit:
                            _menuMethods.PrintToConsole("Exiting the app..");
                            exitMenu = true;
                            break;
                    }
                }
                else
                {
                    _menuMethods.PrintToConsole("Invalid input. The only valid input range is ( 1 - 8");
                }

                if (!exitMenu)
                {
                    _menuMethods.Continue();
                }
            }
        }



        private static bool ValidateUserChoice(string userInput, out MenuChoice userChoice)
        {
            if (Enum.TryParse(userInput, out userChoice) && Enum.IsDefined(typeof(MenuChoice), userChoice))
            {
                return true;
            }

            userChoice = default;
            return false;
        }



        private enum MenuChoice
        {
            StudentSearch = 1,
            GetStudentsInAClass,
            AddEmployee,
            AllEmployeesByRole,
            AllGradeRecentMonth,
            AverageGradeForAllCourses,
            AddStudent,
            Exit
        }








    }
}
