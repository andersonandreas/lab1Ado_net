public interface ISqlSearch
{
    void AddNewEmployee(string firstName, string lastName, string role);
    void AddNewStudent(string personNumber, string firstName, string lastName, string className);
    void CourseAveragesGrades();
    void GetAllEmployees();
    void GetAllStudents(string sortBy, string sortOrder);
    void GetEmployeeByRole(string? empRole = null);
    void RecentGrades();
    void SearchInClass(string className);
    void ShowAllClasses();
}