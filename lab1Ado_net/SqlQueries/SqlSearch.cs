using lab1Ado_net.DatabaseHandler;

public class SqlSearch : ISqlSearch
{


    private readonly IDbHandler _dbHandler;

    public SqlSearch(IDbHandler dbHandler)
    {
        _dbHandler = dbHandler;
    }




    public void GetAllStudents(string sortBy, string sortOrder)
    {
        string query =
            $"SELECT PersonNumber, FirstName, LastName, Class FROM Students " +
            $"ORDER BY {sortBy} {sortOrder}";

        _dbHandler.RunQueryAndPrint(query);
    }


    public void SearchInClass(string className)
    {
        string query =
            $"SELECT PersonNumber, FirstName, LastName, Class " +
            $"FROM Students " +
            $"WHERE Students.Class = '{className}'";

        _dbHandler.RunQueryAndPrint(query);
    }


    public void ShowAllClasses()
    {
        string query =
            $"SELECT DISTINCT Class FROM students";

        _dbHandler.RunQueryAndPrint(query);
    }


    public void AddNewEmployee(string firstName, string lastName, string role)
    {
        string query =
            $"INSERT INTO Employees (FirstName, LastName, EmployeeRole) " +
            $"VALUES ('{firstName}', '{lastName}', '{role}')";

        _dbHandler.AddToDatabase(query);
    }


    public void AddNewStudent(
        string personNumber, string firstName, string lastName, string className)
    {
        string query =
            $"INSERT INTO Students (PersonNumber,FirstName, LastName, Class) " +
            $"VALUES ('{personNumber}','{firstName}', '{lastName}', '{className}')";

        _dbHandler.AddToDatabase(query);
    }



    public void GetEmployeeByRole(string? empRole = null)
    {
        string role = string.IsNullOrEmpty
            (empRole) ? "" : $"WHERE EmployeeRole = '{empRole}'";

        string query = $"SELECT FirstName, LastName, EmployeeRole FROM Employees {role}";

        _dbHandler.RunQueryAndPrint(query);
    }

    public void GetAllEmployees()
    {
        string query =
            $"SELECT FirstName, LastName, EmployeeRole FROM Employees";

        _dbHandler.RunQueryAndPrint(query);
    }


    public void RecentGrades()
    {
        string query =
            "SELECT Students.FirstName, Students.LastName, Courses.CourseName, Grades.Grade " +
            "FROM Students " +
            "JOIN Grades ON Students.StudentID = Grades.StudentID " +
            "JOIN Courses ON Grades.CourseID = Courses.CourseID " +
            "WHERE Grades.DateGrade >= DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0)";

        _dbHandler.RunQueryAndPrint(query);
    }


    public void CourseAveragesGrades()
    {
        string query =
            "SELECT Courses.CourseName, AVG(Grades.Grade) AS AverageGrade, " +
            "MAX(Grades.Grade) AS MaxGrade, MIN(Grades.Grade) AS MinGrade " +
            "FROM Courses " +
            "JOIN Grades ON Courses.CourseID = Grades.CourseID " +
            "GROUP BY Courses.CourseName";

        _dbHandler.RunQueryAndPrint(query);
    }






}
