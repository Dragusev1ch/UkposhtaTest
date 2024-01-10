using DALUkrposhtaTest.DbService.DataAccess;
using DALUkrposhtaTest.Entity;

namespace DALUkrposhtaTest.Pl;

public class CompanyInfoMenu
{
    private readonly CompanyInfoDataAccess _companyInfoDataAccess;

    public CompanyInfoMenu(string connectionString)
    {
        _companyInfoDataAccess = new CompanyInfoDataAccess(connectionString);
    }

    public void ShowMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Add Company");
            Console.WriteLine("2. Get Company");
            Console.WriteLine("3. Update Company");
            Console.WriteLine("4. Delete Company");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddCompany();
                    break;
                case 2:
                    GetCompany();
                    break;
                case 3:
                    UpdateCompany();
                    break;
                case 4:
                    DeleteCompany();
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

    private void AddCompany()
    {
        var company = new CompanyInfo();

        Console.WriteLine("Enter Company Details:");
        Console.Write("Company ID: ");
        company.CompanyID = Convert.ToInt32(Console.ReadLine());

        Console.Write("Company Name: ");
        company.CompanyName = Console.ReadLine();

        Console.Write("Address: ");
        company.Address = Console.ReadLine();

        Console.Write("Phone: ");
        company.Phone = Console.ReadLine();

        _companyInfoDataAccess.AddCompany(company);
        Console.WriteLine("Company added successfully.");
        Console.WriteLine("Press any key to return to the Company Menu...");
        Console.ReadKey();
        Console.Clear();
    }

    private void GetCompany()
    {
        Console.Write("Enter Company ID to retrieve: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var company = _companyInfoDataAccess.GetCompany(id);
        if (company != null)
        {
            Console.WriteLine($"ID: {company.CompanyID}, Name: {company.CompanyName}");
            Console.WriteLine("Press any key to return to the Company Menu...");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Company not found.");
            Console.WriteLine("Press any key to return to the Company Menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private void UpdateCompany()
    {
        Console.Write("Enter Company ID to update: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var company = _companyInfoDataAccess.GetCompany(id);
        if (company == null)
        {
            Console.WriteLine("Company not found.");
            Console.WriteLine("Press any key to return to the Company Menu...");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Console.WriteLine("Enter new details for the company (leave blank to keep current value):");

        Console.Write("Company Name (" + company.CompanyName + "): ");
        var companyNameInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(companyNameInput))
            company.CompanyName = companyNameInput;

        Console.Write("Address (" + company.Address + "): ");
        var addressInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(addressInput))
            company.Address = addressInput;

        Console.Write("Phone (" + company.Phone + "): ");
        var phoneInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(phoneInput))
            company.Phone = phoneInput;

        _companyInfoDataAccess.UpdateCompany(company);
        Console.WriteLine("Company updated successfully.");
        Console.WriteLine("Press any key to return to the Company Menu...");
        Console.ReadKey();
        Console.Clear();
    }

    private void DeleteCompany()
    {
        Console.Write("Enter Company ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        _companyInfoDataAccess.DeleteCompany(id);
        Console.WriteLine("Company deleted successfully.");
        Console.WriteLine("Press any key to return to the Company Menu...");
        Console.ReadKey();
        Console.Clear();
    }
}