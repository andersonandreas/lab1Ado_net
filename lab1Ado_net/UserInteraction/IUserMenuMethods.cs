namespace lab1Ado_net.UserInteraction
{
    public interface IUserMenuMethods
    {
        void AllEmployeesOurByRole();
        void AllGradeRecentMonth();
        void AverageGradeForAllCourses();
        void Continue();
        void GetStudentsInAClass();
        void InputForAddEmp();
        void InputForAddStudent();
        void InputForStudentSearch();
        void PrintToConsole(string message);
        void PrintUserChoice();
        string PromptAndReadUserInput(string prompt);
        string? ReadUserInput();
    }
}