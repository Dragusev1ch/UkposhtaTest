using DALUkrposhtaTest.DbService.DataAccess;
using DALUkrposhtaTest.Entity;

namespace DALUkrposhtaTest.Pl;

public class DepartmentMenu
{
    private readonly DepartmentDataAccess _departmentDataAccess;

    public DepartmentMenu(string connectionString)
    {
        _departmentDataAccess = new DepartmentDataAccess(connectionString);
    }

    public void ShowMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Add Department");
            Console.WriteLine("2. Get Department");
            Console.WriteLine("3. Update Department");
            Console.WriteLine("4. Delete Department");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddDepartment();
                    break;
                case 2:
                    GetDepartment();
                    break;
                case 3:
                    UpdateDepartment();
                    break;
                case 4:
                    DeleteDepartment();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void AddDepartment()
    {
        var department = new Department();

        Console.WriteLine("Enter Department Details:");
        Console.Write("Department ID: ");
        department.DepartmentID = Convert.ToInt32(Console.ReadLine());

        Console.Write("Department Name: ");
        department.DepartmentName = Console.ReadLine();

        _departmentDataAccess.AddDepartment(department);
        Console.WriteLine("Department added successfully.");
        Console.WriteLine("Press any key to return to the Department Menu...");
        Console.ReadKey();
        Console.Clear();
    }

    private void GetDepartment()
    {
        Console.Write("Enter Department ID to retrieve: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var department = _departmentDataAccess.GetDepartment(id);
        if (department != null)
        {
            Console.WriteLine($"ID: {department.DepartmentID}, Name: {department.DepartmentName}");
            Console.WriteLine("Press any key to return to the Department Menu...");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Department not found.");
            Console.WriteLine("Press any key to return to the Department Menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private void UpdateDepartment()
    {
        Console.Write("Enter Department ID to update: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var department = _departmentDataAccess.GetDepartment(id);
        if (department == null)
        {
            Console.WriteLine("Department not found.");
            Console.WriteLine("Press any key to return to the Department Menu...");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Console.WriteLine("Enter new details for the department (leave blank to keep current value):");

        Console.Write("Department Name (" + department.DepartmentName + "): ");
        var departmentNameInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(departmentNameInput))
            department.DepartmentName = departmentNameInput;

        _departmentDataAccess.UpdateDepartment(department);
        Console.WriteLine("Department updated successfully.");
        Console.WriteLine("Press any key to return to the Department Menu...");
        Console.ReadKey();
        Console.Clear();
    }

    private void DeleteDepartment()
    {
        Console.Write("Enter Department ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        _departmentDataAccess.DeleteDepartment(id);
        Console.WriteLine("Department deleted successfully.");
        Console.WriteLine("Press any key to return to the Department Menu...");
        Console.ReadKey();
        Console.Clear();
    }
}