namespace Services;

using System;
using Vehicles;

public static class VehicleManager
{
    private static Vehicle[] vehicles = [];
    private static int count = 0;

    public static Vehicle[] Vehicles => vehicles;

    public static string[,]? PrintVehicles(Vehicle[]? _vehicles = null)
    {
        Vehicle[] printedVehicles = _vehicles ?? vehicles;
        if (printedVehicles == null || vehicles.Length == 0)
        {
            Console.WriteLine("No vehicles found.");
            return null;
        }

        Console.WriteLine("Current vehicles:");
        Console.WriteLine(new string('-', 100));
        Console.WriteLine(
            $"{"Name",-15} {"Price",-20} {"Speed",-10} {"Type",-15} {"Special Features",-40}"
        );
        Console.WriteLine(new string('-', 100));

        string[,] result = new string[printedVehicles.Length, 5];
        for (int i = 0; i < printedVehicles.Length; i++)
        {
            string specialFeatures = printedVehicles[i].GetSpecialFeatures();

            Console.WriteLine(
                $"{printedVehicles[i].Name,-15} {printedVehicles[i].Price,-20:C} {printedVehicles[i].Speed,-10:F1} {printedVehicles[i].VehicleType,-15} {specialFeatures,-40}"
            );
            
            result[i, 0] = printedVehicles[i].Name;
            result[i, 1] = printedVehicles[i].Price.ToString();
            result[i, 2] = printedVehicles[i].Speed.ToString();
            result[i, 3] = printedVehicles[i].VehicleType;
            result[i, 4] = specialFeatures;
        }
        Console.WriteLine(new string('-', 100));
        Console.WriteLine($"Total vehicles: {printedVehicles.Length}");
        
        return result;
    }

    public static Vehicle[]? SearchVehicles(string searchQuery)
    {
        Vehicle[] foundVehicles = new Vehicle[vehicles.Length];
        int foundCount = 0;

        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i].Name.ToLower().Contains(searchQuery.ToLower()))
            {
                foundVehicles[foundCount] = vehicles[i];
                foundCount++;
            }
        }

        if (foundCount == 0)
        {
            Console.WriteLine("No vehicles found.");
            return null;
        }

        Vehicle[] result = new Vehicle[foundCount];
        for (int i = 0; i < foundCount; i++)
        {
            result[i] = foundVehicles[i];
        }

        return result;
    }

    public static bool VehicleExists(Vehicle vehicle)
    {
        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i].Equals(vehicle))
            {
                return true;
            }
        }

        return false;
    }

    public static void RemoveVehicle(Vehicle vehicle)
    {
        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i].Equals(vehicle))
            {
                for (int j = i; j < vehicles.Length - 1; j++)
                {
                    vehicles[j] = vehicles[j + 1];
                }
                count--;
                break;
            }
        }
    }

    public static void AddVehicle(Vehicle vehicle)
    {
        if (VehicleExists(vehicle))
        {
            Console.WriteLine("Vehicle already exists.");
            return;
        }

        Vehicle[] newVehicles = new Vehicle[vehicles.Length + 1];
        for (int i = 0; i < vehicles.Length; i++)
        {
            newVehicles[i] = vehicles[i];
        }
        vehicles = newVehicles;

        vehicles[count] = vehicle;
        count++;
    }

    public static void ClearVehicles()
    {
        vehicles = [];
        count = 0;
    }
}
