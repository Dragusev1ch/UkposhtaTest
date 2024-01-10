namespace DALUkrposhtaTest.Entity;

public class Employee
{
    public int EmployeeID { get; set; }
    public int DepartmentID { get; set; }
    public int PositionID { get; set; }
    public int CompanyID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
}