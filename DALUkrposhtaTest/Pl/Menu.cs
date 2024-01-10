namespace DALUkrposhtaTest.Pl;

public class Menu
{
    private readonly EmployeeMenu _employeeMenu;
    private readonly DepartmentMenu _departmentMenu;
    private readonly CompanyInfoMenu _companyInfoMenu;
    private readonly PositionMenu _positionMenu;



    public Menu(string connectionString)
    {
        _employeeMenu = new EmployeeMenu(connectionString);
        _departmentMenu = new DepartmentMenu(connectionString);
        _companyInfoMenu = new CompanyInfoMenu(connectionString);
        _positionMenu = new PositionMenu(connectionString);
    }

    public void ShowMainMenu()
    {
        bool exit = false;
        while (!exit)
        {
            try
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Employee Menu");
                Console.WriteLine("2. Department Menu");
                Console.WriteLine("3. Company Info Menu");
                Console.WriteLine("4. Position Menu");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        _employeeMenu.ShowMenu();
                        break;
                    case 2:
                        _departmentMenu.ShowMenu();
                        break;
                    case 3:
                        _companyInfoMenu.ShowMenu();
                        break;
                    case 4:
                        _positionMenu.ShowMenu();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            if (!exit)
            {
                Console.WriteLine("Press any key to return to the Main Menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}