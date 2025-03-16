namespace Services;

using System;
using Vehicles;

public static class VehicleManager
{
    private static Vehicle[] vehicles = [];
    private static int count = 0;

    public static Vehicle[] Vehicles => vehicles;

    public static string[,]? PrintVehicles()
    {
        if (vehicles == null || vehicles.Length == 0)
        {
            Console.WriteLine("No vehicles found.");
            return null;
        }

        Console.WriteLine("Current Vehicles:");
        Console.WriteLine(new string('-', 100));
        Console.WriteLine(
            $"{"Name",-20} {"Price",-10} {"Speed",-10} {"Type",-15} {"Special Features",-40}"
        );
        Console.WriteLine(new string('-', 100));

        string[,] result = new string[vehicles.Length, 5];
        for (int i = 0; i < vehicles.Length; i++)
        {
            string specialFeatures = vehicles[i].GetSpecialFeatures();

            Console.WriteLine(
                $"{vehicles[i].Name,-20} ${vehicles[i].Price,-9:C} {vehicles[i].Speed,-10:F1} {vehicles[i].VehicleType,-15} {specialFeatures,-40}"
            );
            
            result[i, 0] = vehicles[i].Name;
            result[i, 1] = vehicles[i].Price.ToString();
            result[i, 2] = vehicles[i].Speed.ToString();
            result[i, 3] = vehicles[i].VehicleType;
            result[i, 4] = specialFeatures;
        }
        Console.WriteLine(new string('-', 100));
        Console.WriteLine($"Total vehicles: {vehicles.Length}");
        
        return result;
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
