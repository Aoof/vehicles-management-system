namespace UserInterface;

using System;
using Services;
using Exceptions;
using static Cli;

public static class UserInterface
{
    // In Run method, I was going to check for flags and run the CLI or GUI version of the program.
    // GUI that works on both Windows, Linux and MacOS is a bit more complicated than CLI.
    // I found Avalonia, but it's difficult to implement on top of the CLI version.
    // I will leave it as a future improvement.
    public static void Run(string[] args)
    {
        if (args.Length > 0 && (args[0] == "--test" || args[0] == "-t"))
        {
            Tester.RunTests();
            return;
        }

        try
        { FileHandler.LoadFromFile(); }
        catch (FileHandlingException ex)
        { Console.WriteLine(ex.Message); }
        catch (Exception ex)
        { Console.WriteLine($"An unexpected error occurred: {ex.Message}"); }
        
        Run_CLI();
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
                    case 9:
                        SearchVehicle();
                        break;
                    case 10:
                        Tester.RunTests();
                        break; 
                    case 0:
                        exit = true;
                        FileHandler.SaveToFile();
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
