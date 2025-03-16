namespace UserInterface;

using System;
using Exceptions;
using static Cli;

public static class UserInterface
{
    public static void Run(string[] args)
    {
        if (args.Length > 0 && (args[0] == "--gui" || args[0] == "-g"))
        { Run_GUI(); } 
        else
        { Run_CLI(); }
    }

    public static void Run_GUI()
    {
        Console.WriteLine("Running GUI version of the program...");
        Console.WriteLine("GUI version is not implemented yet.");
        // TODO: Implement GUI version
    }

    public static void Run_CLI()
    {
        Console.WriteLine("Vehicle Management System - CLI Version");
        Console.WriteLine("=======================================");

        bool exit = false;
        while (!exit)
        {
            try
            {
                DisplayMainMenu();
                int choice = GetIntInput("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        AddVehicleMenu();
                        break;
                    case 2:
                        ListVehicles();
                        break;
                    case 3:
                        SortVehicles();
                        break;
                    case 4:
                        CalculateTaxes();
                        break;
                    case 5:
                        RemoveVehicle();
                        break;
                    case 6:
                        SaveToFile();
                        break;
                    case 7:
                        LoadFromFile();
                        break;
                    case 8:
                        GenerateStatistics();
                        break;
                    case 0:
                        exit = true;
                        Console.WriteLine("Thank you for using Vehicle Management System. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (VehicleException ex)
            {
                Console.WriteLine($"Vehicle Error: {ex.Message}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
