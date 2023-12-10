using System.Text.RegularExpressions;

namespace lab1Ado_net.UserInteraction
{
    public class UserMenuMethods : IUserMenuMethods
    {

        private readonly ISqlSearch _sqlHelper;


        public UserMenuMethods(ISqlSearch sqlHelper)
        {
            _sqlHelper = sqlHelper;

        }



        public void InputForStudentSearch()
        {
            ClearConsole();
            var userInput = PromptAndReadUserInput("Sort by, enter 'firstname' or 'lastname'");

            if (string.IsNullOrEmpty(userInput))
            {
                PrintToConsole("Not a valid input..");
                userInput = PromptAndReadUserInput("Sort by, enter 'firstname' or 'lastname'");
            }


            // making the first character uppercase and replaces the lowercase n with uppercase N,
            // to match my row in SQL server db
            var formtatInput = char.ToUpper(userInput[0]) + userInput[1..];
            var sortBy = Regex.Replace(formtatInput, "n", "N");
            var sortOrder = PromptAndReadUserInput("Order by, Enter 'asc' or 'desc'").ToUpper();

            if (sortBy == "FirstName" || sortBy == "LastName" && sortOrder == "ASC" || sortOrder == "DESC")
            {
                ClearConsole();

                _sqlHelper.GetAllStudents(sortBy, sortOrder);
                return;
            }

            PrintToConsole("You entered the wrong choices.");
            return;
        }


        public void GetStudentsInAClass()
        {
            ClearConsole();
            _sqlHelper.ShowAllClasses();

            var classInput = PromptAndReadUserInput(
                "Enter the name of the class to get the students in it:");

            if (classInput is not null)
            {
                ClearConsole();
                _sqlHelper.SearchInClass(classInput);
                return;
            }

            PrintToConsole("No class with that name.");
            return;
        }


        public void AllGradeRecentMonth()
        {
            ClearConsole();
            PrintToConsole("Grade info: (0 = IG, 1 = G, 2 = VG)." + Environment.NewLine);

            _sqlHelper.RecentGrades();
        }



        public void AllEmployeesOurByRole()
        {
            ClearConsole();

            var userChoice = PromptAndReadUserInput(
                "Press 1 for all employees our press 2 to search employee by role");

            if (userChoice == "1")
            {
                ClearConsole();
                _sqlHelper.GetEmployeeByRole();
                return;
            }

            if (userChoice == "2")
            {
                var searchRole = PromptAndReadUserInput("Enter the role");
                ClearConsole();

                _sqlHelper.GetEmployeeByRole(searchRole);
                return;
            }

            PrintToConsole("Wrong input");
            return;
        }



        public void InputForAddEmp()
        {
            ClearConsole();

            string firstName = PromptAndReadUserInput("Enter firstName");
            string lastName = PromptAndReadUserInput("Enter lastName");
            string role = PromptAndReadUserInput("Enter the employee role");

            if (string.IsNullOrEmpty(firstName)
                || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(role))
            {
                PrintToConsole("Wrong input..");
                return;
            }

            _sqlHelper.AddNewEmployee(firstName, lastName, role);
            PrintToConsole($"Employee added: {firstName} {lastName} {role}");
        }

        public void InputForAddStudent()
        {
            ClearConsole();

            string PersonNumber = PromptAndReadUserInput("Enter PersonNumber");
            string firstName = PromptAndReadUserInput("Enter firstName");
            string lastName = PromptAndReadUserInput("Enter lastName");
            string className = PromptAndReadUserInput("Enter className");

            if (string.IsNullOrEmpty(PersonNumber) || string.IsNullOrEmpty(firstName)
                || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(className))
            {
                PrintToConsole("No valid input.");
                return;
            }

            _sqlHelper.AddNewStudent(PersonNumber, firstName, lastName, className);
            PrintToConsole($"Student added: {firstName} {lastName}");
        }


        public void AverageGradeForAllCourses()
        {
            ClearConsole();
            _sqlHelper.CourseAveragesGrades();
        }


        public void PrintUserChoice()
        {

            string[] menuOptions =
           {
            "Get all students",
            "Get Students in a class",
            "Add new employee",
            "Get all employees our search by role",
            "Recent grades",
            "Course averages grades",
            "Add new student",
            "Exit"
           };

            for (int i = 0; i < menuOptions.Length; i++)
            {
                PrintToConsole($"{i + 1}. {menuOptions[i]}");
            }

        }

        public void Continue()
        {
            PrintToConsole("Press Enter to continue to main menu..." + Environment.NewLine);
            Console.ReadKey();
            ClearConsole();
        }




        // 4 methods for console printing and reading user input
        public string PromptAndReadUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            return ReadUserInput()!;
        }
        public string? ReadUserInput() => Console.ReadLine()?.Trim();

        public void PrintToConsole(string message) => Console.WriteLine(message);

        private static void ClearConsole() => Console.Clear();





    }
}
