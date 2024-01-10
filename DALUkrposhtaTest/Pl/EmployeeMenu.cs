using DALUkrposhtaTest.DbService.DataAccess;
using DALUkrposhtaTest.Entity;
using DALUkrposhtaTest.Services;

namespace DALUkrposhtaTest.Pl;

public class EmployeeMenu
{
    private readonly EmployeeDataAccess _employeeDataAccess;
    private readonly EmployeeService _employeeService;

    public EmployeeMenu(string connectionString)
    {
        _employeeDataAccess = new EmployeeDataAccess(connectionString);
        _employeeService = new EmployeeService(_employeeDataAccess);
    }

    public void ShowMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Get Employee");
            Console.WriteLine("3. Get All Employees");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    GetEmployee();
                    break;
                case 3:
                    GetAllEmployees();
                    break;
                case 4:
                    UpdateEmployee();
                    break;
                case 5:
                    DeleteEmployee();
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void AddEmployee()
    {
        var employee = new Employee();

        Console.WriteLine("Enter Employee Details:");
        Console.Write("Employee ID: ");
        employee.EmployeeID = Convert.ToInt32(Console.ReadLine());

        Console.Write("Department ID: ");
        employee.DepartmentID = Convert.ToInt32(Console.ReadLine());

        Console.Write("Position ID: ");
        employee.PositionID = Convert.ToInt32(Console.ReadLine());

        Console.Write("Company ID: ");
        employee.CompanyID = Convert.ToInt32(Console.ReadLine());

        Console.Write("Last Name: ");
        employee.LastName = Console.ReadLine();

        Console.Write("First Name: ");
        employee.FirstName = Console.ReadLine();

        Console.Write("Middle Name: ");
        employee.MiddleName = Console.ReadLine();

        Console.Write("Address: ");
        employee.Address = Console.ReadLine();

        Console.Write("Phone: ");
        employee.Phone = Console.ReadLine();

        Console.Write("Birth Date (yyyy-MM-dd): ");
        employee.BirthDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Hire Date (yyyy-MM-dd): ");
        employee.HireDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Salary: ");
        employee.Salary = Convert.ToDecimal(Console.ReadLine());

        _employeeDataAccess.AddEmployee(employee);
        Console.WriteLine("Employee added successfully.");
        Console.WriteLine("Press any key to return to the Employee Menu...");
        Console.ReadKey();
        Console.Clear();
    }

    private void GetEmployee()
    {
        Console.Write("Enter Employee ID to retrieve: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var employee = _employeeDataAccess.GetEmployee(id);
        if (employee != null)
        {
            // Display the details of the employee
            Console.WriteLine($"ID: {employee.EmployeeID}, " +
                              $"Name: {employee.FirstName} {employee.LastName} {employee.MiddleName}" +
                              $"Salary: {employee.Salary}");
            Console.WriteLine("Press any key to return to the Employee Menu...");
            Console.ReadKey();
            Console.Clear();
            // Add more details as needed
        }
        else
        {
            Console.WriteLine("Employee not found.");
            Console.WriteLine("Press any key to return to the Employee Menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private void GetAllEmployees()
    {
        Console.WriteLine("Get and Sort All Employees");

        Console.WriteLine("Choose a sort criteria:");
        Console.WriteLine("1. Position");
        Console.WriteLine("2. Department");
        Console.WriteLine("3. Last Name");
        Console.WriteLine("4. Birth Date");
        Console.WriteLine("5. Salary");
        Console.Write("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        string sortBy = "";
        switch (choice)
        {
            case 1:
                sortBy = "position";
                break;
            case 2:
                sortBy = "department";
                break;
            case 3:
                sortBy = "lastname";
                break;
            case 4:
                sortBy = "birthdate";
                break;
            case 5:
                sortBy = "salary";
                break;
            default:
                Console.WriteLine("Invalid choice. Defaulting to Last Name.");
                sortBy = "lastname";
                break;
        }

        Console.Write("Sort ascending? (yes/no): ");
        bool ascending = Console.ReadLine().ToLower() == "yes";

        var sortedEmployees = _employeeService.GetEmployeesSorted(sortBy, ascending);
        foreach (var employee in sortedEmployees)
        {
            Console.WriteLine($"ID: {employee.EmployeeID}, " +
                              $"Name: {employee.FirstName} {employee.LastName} {employee.MiddleName}," 
                              + $"Salary: {employee.Salary}");
        }

        Console.Write("Do you want to export these employees to a text file? (yes/no): ");
        string exportChoice = Console.ReadLine().ToLower();
        if (exportChoice == "yes")
        {
            Console.Write("Enter file path to save the data or press Enter to use default path: ");
            string filePath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filePath))
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                filePath = Path.Combine(baseDir, "sorted_employees.txt");
            }

            try
            {
                _employeeService.ExportEmployeesToTxtFile(sortBy, ascending, filePath);
                Console.WriteLine($"Employees exported successfully to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during export: {ex.Message}");
            }
        }

        Console.WriteLine("Press any key to return to the Employee Menu...");
        Console.ReadKey();
        Console.Clear();
    }


    private void UpdateEmployee()
    {
        Console.Write("Enter Employee ID to update: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var employee = _employeeDataAccess.GetEmployee(id);
        if (employee == null)
        {
            Console.WriteLine("Employee not found.");
            Console.WriteLine("Press any key to return to the Employee Menu...");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Console.WriteLine("Enter new details for the employee (leave blank to keep current value):");

        Console.Write("Department ID (" + employee.DepartmentID + "): ");
        var departmentIdInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(departmentIdInput))
            employee.DepartmentID = Convert.ToInt32(departmentIdInput);

        // EmployeeID should not typically be changed, so it's not included here

        Console.Write("Position ID (" + employee.PositionID + "): ");
        var positionIdInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(positionIdInput))
            employee.PositionID = Convert.ToInt32(positionIdInput);

        Console.Write("Company ID (" + employee.CompanyID + "): ");
        var companyIdInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(companyIdInput))
            employee.CompanyID = Convert.ToInt32(companyIdInput);

        Console.Write("Last Name: ");
        var lastNameInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(lastNameInput))
            employee.LastName = lastNameInput;

        Console.Write("First Name: ");
        var firstNameInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(firstNameInput))
            employee.FirstName = firstNameInput;

        Console.Write("Middle Name: ");
        var middleNameInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(middleNameInput))
            employee.MiddleName = middleNameInput;

        Console.Write("Address: ");
        var addressInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(addressInput))
            employee.Address = addressInput;

        Console.Write("Phone: ");
        var phoneInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(phoneInput))
            employee.Phone = phoneInput;

        Console.Write("Birth Date (yyyy-MM-dd): ");
        var birthDateInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(birthDateInput))
            employee.BirthDate = DateTime.Parse(birthDateInput);

        Console.Write("Hire Date (yyyy-MM-dd): ");
        var hireDateInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(hireDateInput))
            employee.HireDate = DateTime.Parse(hireDateInput);

        Console.Write("Salary: ");
        var salaryInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(salaryInput))
            employee.Salary = Convert.ToDecimal(salaryInput);

        _employeeDataAccess.UpdateEmployee(employee);
        Console.WriteLine("Employee updated successfully.");
        Console.WriteLine("Press any key to return to the Employee Menu...");
        Console.ReadKey();
        Console.Clear();
    }

    private void DeleteEmployee()
    {
        Console.Write("Enter Employee ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        _employeeDataAccess.DeleteEmployee(id);
        Console.WriteLine("Employee deleted successfully.");
        Console.WriteLine("Press any key to return to the Employee Menu...");
        Console.ReadKey();
        Console.Clear();
    }
}
