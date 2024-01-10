using DALUkrposhtaTest.DbService.DataAccess;
using DALUkrposhtaTest.Entity;

namespace DALUkrposhtaTest.Pl;

public class PositionMenu
{
    private readonly PositionDataAccess _positionDataAccess;

    public PositionMenu(string connectionString)
    {
        _positionDataAccess = new PositionDataAccess(connectionString);
    }

    public void ShowMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Add Position");
            Console.WriteLine("2. Get Position");
            Console.WriteLine("3. Update Position");
            Console.WriteLine("4. Delete Position");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddPosition();
                    break;
                case 2:
                    GetPosition();
                    break;
                case 3:
                    UpdatePosition();
                    break;
                case 4:
                    DeletePosition();
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

    private void AddPosition()
    {
        var position = new Position();

        Console.WriteLine("Enter Position Details:");
        Console.Write("Position ID: ");
        position.PositionID = Convert.ToInt32(Console.ReadLine());

        Console.Write("Position Name: ");
        position.PositionName = Console.ReadLine();

        _positionDataAccess.AddPosition(position);
        Console.WriteLine("Position added successfully.");
        Console.WriteLine("Press any key to return to the Position Menu...");
        Console.ReadKey();
        Console.Clear();
    }

    private void GetPosition()
    {
        Console.Write("Enter Position ID to retrieve: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var position = _positionDataAccess.GetPosition(id);
        if (position != null)
        {
            Console.WriteLine($"ID: {position.PositionID}, Name: {position.PositionName}");
            Console.WriteLine("Press any key to return to the Position Menu...");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Position not found.");
            Console.WriteLine("Press any key to return to the Position Menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private void UpdatePosition()
    {
        Console.Write("Enter Position ID to update: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var position = _positionDataAccess.GetPosition(id);
        if (position == null)
        {
            Console.WriteLine("Position not found.");
            Console.WriteLine("Press any key to return to the Position Menu...");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Console.WriteLine("Enter new details for the position (leave blank to keep current value):");

        Console.Write("Position Name (" + position.PositionName + "): ");
        var positionNameInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(positionNameInput))
            position.PositionName = positionNameInput;

        _positionDataAccess.UpdatePosition(position);
        Console.WriteLine("Position updated successfully.");
        Console.WriteLine("Press any key to return to the Position Menu...");
        Console.ReadKey();
        Console.Clear();
    }

    private void DeletePosition()
    {
        Console.Write("Enter Position ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        _positionDataAccess.DeletePosition(id);
        Console.WriteLine("Position deleted successfully.");
        Console.WriteLine("Press any key to return to the Position Menu...");
        Console.ReadKey();
        Console.Clear();
    }
}