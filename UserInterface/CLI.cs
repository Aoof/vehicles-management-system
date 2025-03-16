namespace UserInterface;

using System;
using Vehicles;
using IndependentClasses;
using Services;

public static class Cli
{
    public static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Vehicle Management System - Main Menu");
        Console.WriteLine("====================================");
        Console.WriteLine("1. Add new vehicle");
        Console.WriteLine("2. List all vehicles");
        Console.WriteLine("3. Sort vehicles");
        Console.WriteLine("4. Calculate taxes for all vehicles");
        Console.WriteLine("5. Remove vehicle");
        Console.WriteLine("6. Save vehicles to file");
        Console.WriteLine("7. Load vehicles from file");
        Console.WriteLine("8. Generate vehicle statistics");
        Console.WriteLine("0. Exit");
        Console.WriteLine("====================================");
    }

    public static void AddVehicleMenu()
    {
        Console.Clear();
        Console.WriteLine("Add Vehicle - Select Type");
        Console.WriteLine("========================");
        Console.WriteLine("1. Car");
        Console.WriteLine("2. Truck");
        Console.WriteLine("3. Boat");
        Console.WriteLine("4. Train");
        Console.WriteLine("5. Airplane");
        Console.WriteLine("6. Race Car");
        Console.WriteLine("7. Luxury Yacht");
        Console.WriteLine("8. Cargo Airplane");
        Console.WriteLine("0. Back to Main Menu");
        Console.WriteLine("========================");

        int choice = GetIntInput("Enter your choice: ");

        if (choice == 0) return;

        try
        {
            Vehicle? vehicle = null;
            switch (choice)
            {
                case 1:
                    vehicle = CreateCar();
                    break;
                case 2:
                    vehicle = CreateTruck();
                    break;
                case 3:
                    vehicle = CreateBoat();
                    break;
                case 4:
                    vehicle = CreateTrain();
                    break;
                case 5:
                    vehicle = CreateAirplane();
                    break;
                case 6:
                    vehicle = CreateRaceCar();
                    break;
                case 7:
                    vehicle = CreateLuxuryYacht();
                    break;
                case 8:
                    vehicle = CreateCargoAirplane();
                    break;
                default:
                    Console.WriteLine("Invalid option. Returning to main menu.");
                    return;
            }

            if (vehicle != null)
            {
                VehicleManager.AddVehicle(vehicle);
                Console.WriteLine("Vehicle added successfully!");
                vehicle.DisplayInfo();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding vehicle: {ex.Message}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    public static void ListVehicles()
    {
        Console.Clear();
        Console.WriteLine("Vehicle List");
        Console.WriteLine("============");
        
        var result = VehicleManager.PrintVehicles();
        
        if (result == null)
        {
            Console.WriteLine("No vehicles to display.");
        }
        
        Console.WriteLine("\nPress any key to return to main menu...");
        Console.ReadKey();
    }

    public static void SortVehicles()
    {
        if (VehicleManager.Vehicles.Length == 0)
        {
            Console.WriteLine("No vehicles to sort. Please add vehicles first.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        Console.WriteLine("Sort Vehicles");
        Console.WriteLine("=============");
        Console.WriteLine("1. Sort by Price");
        Console.WriteLine("2. Sort by Speed");
        Console.WriteLine("3. Sort by Type");
        Console.WriteLine("0. Back to Main Menu");

        int choice = GetIntInput("Enter your choice: ");

        try
        {
            switch (choice)
            {
                case 0:
                    return;
                case 1:
                    VehicleComparer.SortByPrice(VehicleManager.Vehicles);
                    Console.WriteLine("Vehicles sorted by price.");
                    break;
                case 2:
                    VehicleComparer.SortBySpeed(VehicleManager.Vehicles);
                    Console.WriteLine("Vehicles sorted by speed.");
                    break;
                case 3:
                    VehicleComparer.SortByType(VehicleManager.Vehicles);
                    Console.WriteLine("Vehicles sorted by type.");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sorting vehicles: {ex.Message}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    public static void CalculateTaxes()
    {
        Console.Clear();
        Console.WriteLine("Tax Calculation");
        Console.WriteLine("===============");
        
        if (VehicleManager.Vehicles.Length == 0)
        {
            Console.WriteLine("No vehicles to calculate taxes for. Please add vehicles first.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"{"Name",-20} {"Price",-15} {"Tax",-15} {"Type",-15}");
        Console.WriteLine(new string('-', 65));

        double totalTax = 0;
        foreach (var vehicle in VehicleManager.Vehicles)
        {
            double tax = TaxCalculator.CalculateTax(vehicle);
            totalTax += tax;
            Console.WriteLine($"{vehicle.Name,-20} ${vehicle.Price,-14:N2} ${tax,-14:N2} {vehicle.VehicleType,-15}");
        }

        Console.WriteLine(new string('-', 65));
        Console.WriteLine($"Total Tax: ${totalTax:N2}");
        
        Console.WriteLine("\nPress any key to return to main menu...");
        Console.ReadKey();
    }

    public static void RemoveVehicle()
    {
        if (VehicleManager.Vehicles.Length == 0)
        {
            Console.WriteLine("No vehicles to remove. Please add vehicles first.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        Console.WriteLine("Remove Vehicle");
        Console.WriteLine("==============");
        
        for (int i = 0; i < VehicleManager.Vehicles.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {VehicleManager.Vehicles[i].Name} ({VehicleManager.Vehicles[i].VehicleType})");
        }
        
        int index = GetIntInput("Enter the number of the vehicle to remove (0 to cancel): ");
        
        if (index == 0) return;
        
        if (index > 0 && index <= VehicleManager.Vehicles.Length)
        {
            Vehicle vehicleToRemove = VehicleManager.Vehicles[index - 1];
            VehicleManager.RemoveVehicle(vehicleToRemove);
            Console.WriteLine($"Vehicle '{vehicleToRemove.Name}' removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static void SaveToFile()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Save Vehicles to File");
            Console.WriteLine("====================");
            
            // TODO: Implement file saving functionality
            
            Console.WriteLine("This feature is not implemented yet.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static void LoadFromFile()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Load Vehicles from File");
            Console.WriteLine("======================");
            
            // TODO: Implement file loading functionality
            
            Console.WriteLine("This feature is not implemented yet.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
        }
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static void GenerateStatistics()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Vehicle Statistics");
            Console.WriteLine("=================");
            
            if (VehicleManager.Vehicles.Length == 0)
            {
                Console.WriteLine("No vehicles to generate statistics for. Please add vehicles first.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            
            // TODO: Implement vehicle statistics generation
            Console.WriteLine("This feature is not implemented yet.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error generating statistics: {ex.Message}");
        }
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static Car CreateCar()
    {
        Console.Clear();
        Console.WriteLine("Create New Car");
        Console.WriteLine("=============");
        
        string name = GetStringInput("Enter car name: ");
        double price = GetDoubleInput("Enter price: $");
        double speed = GetDoubleInput("Enter maximum speed (mph): ");
        string type = GetStringInput("Enter car type (e.g., Sedan, SUV): ");
        int horsepower = GetIntInput("Enter horsepower: ");
        string model = GetStringInput("Enter model: ");
        
        return new Car(name, price, speed, type, horsepower, model);
    }

    public static Truck CreateTruck()
    {
        Console.Clear();
        Console.WriteLine("Create New Truck");
        Console.WriteLine("===============");
        
        string name = GetStringInput("Enter truck name: ");
        double price = GetDoubleInput("Enter price: $");
        double speed = GetDoubleInput("Enter maximum speed (mph): ");
        string type = GetStringInput("Enter truck type (e.g., Pickup, Semi): ");
        double loadCapacity = GetDoubleInput("Enter load capacity (tons): ");
        
        return new Truck(name, price, speed, type, loadCapacity);
    }

    public static Boat CreateBoat()
    {
        Console.Clear();
        Console.WriteLine("Create New Boat");
        Console.WriteLine("==============");
        
        string name = GetStringInput("Enter boat name: ");
        double price = GetDoubleInput("Enter price: $");
        double speed = GetDoubleInput("Enter maximum speed (mph): ");
        string type = GetStringInput("Enter boat type (e.g., Speedboat, Sailboat): ");
        double seatingCapacity = GetDoubleInput("Enter seating capacity: ");
        
        return new Boat(name, price, speed, type, seatingCapacity);
    }

    public static Train CreateTrain()
    {
        Console.Clear();
        Console.WriteLine("Create New Train");
        Console.WriteLine("===============");
        
        string name = GetStringInput("Enter train name: ");
        double price = GetDoubleInput("Enter price: $");
        double speed = GetDoubleInput("Enter maximum speed (mph): ");
        string type = GetStringInput("Enter train type (e.g., Passenger, Freight): ");
        int units = GetIntInput("Enter number of units: ");
        
        return new Train(name, price, speed, type, units);
    }

    public static Airplane CreateAirplane()
    {
        Console.Clear();
        Console.WriteLine("Create New Airplane");
        Console.WriteLine("==================");
        
        string name = GetStringInput("Enter airplane name: ");
        double price = GetDoubleInput("Enter price: $");
        double speed = GetDoubleInput("Enter maximum speed (mph): ");
        string type = GetStringInput("Enter airplane type (e.g., Commercial, public): ");
        double altitude = GetDoubleInput("Enter maximum altitude (feet): ");
        
        return new Airplane(name, price, speed, type, altitude);
    }

    public static RaceCar CreateRaceCar()
    {
        Console.Clear();
        Console.WriteLine("Create New Race Car");
        Console.WriteLine("==================");
        
        string name = GetStringInput("Enter race car name: ");
        double price = GetDoubleInput("Enter price: $");
        double speed = GetDoubleInput("Enter maximum speed (mph): ");
        string type = GetStringInput("Enter race car type (e.g., F1, NASCAR): ");
        int horsepower = GetIntInput("Enter horsepower: ");
        string model = GetStringInput("Enter model: ");
        bool turboBoost = GetBoolInput("Does it have turbo boost? (y/n): ");
        
        return new RaceCar(name, price, speed, type, horsepower, model, turboBoost);
    }

    public static LuxuryYacht CreateLuxuryYacht()
    {
        Console.Clear();
        Console.WriteLine("Create New Luxury Yacht");
        Console.WriteLine("======================");
        
        string name = GetStringInput("Enter yacht name: ");
        double price = GetDoubleInput("Enter price: $");
        double speed = GetDoubleInput("Enter maximum speed (mph): ");
        string type = GetStringInput("Enter yacht type (e.g., Motor, Sailing): ");
        double seatingCapacity = GetDoubleInput("Enter seating capacity: ");
        bool helipad = GetBoolInput("Does it have a helipad? (y/n): ");
        
        return new LuxuryYacht(name, price, speed, type, seatingCapacity, helipad);
    }

    public static CargoAirplane CreateCargoAirplane()
    {
        Console.Clear();
        Console.WriteLine("Create New Cargo Airplane");
        Console.WriteLine("=======================");
        
        string name = GetStringInput("Enter cargo airplane name: ");
        double price = GetDoubleInput("Enter price: $");
        double speed = GetDoubleInput("Enter maximum speed (mph): ");
        string type = GetStringInput("Enter cargo airplane type (e.g., Freighter, Military): ");
        double altitude = GetDoubleInput("Enter maximum altitude (feet): ");
        double cargoCapacity = GetDoubleInput("Enter cargo capacity (tons): ");
        
        return new CargoAirplane(name, price, speed, type, altitude, cargoCapacity);
    }

    public static string GetStringInput(string prompt)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        return input ?? string.Empty;
    }

    public static int GetIntInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    public static double GetDoubleInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    public static bool GetBoolInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim().ToLower();
            
            if (input == "y" || input == "yes" || input == "true" || input == "1")
            {
                return true;
            }
            else if (input == "n" || input == "no" || input == "false" || input == "0")
            {
                return false;
            }
            
            Console.WriteLine("Invalid input. Please enter y/n.");
        }
    }

}