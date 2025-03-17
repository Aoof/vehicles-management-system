namespace IndependentClasses;

using System;
using System.Linq;
using Services;
using Vehicles;
using Common;

public static class VehicleStatistics
{
    public static void FindMostEpensiveVehicle()
    {
        if (VehicleManager.Vehicles.Length == 0)
        {
            Console.WriteLine("No vehicles in the system.");
            return;
        }
        
        var sortedVehicles = from vehicle in VehicleManager.Vehicles
                                   orderby vehicle.Price descending
                                   select vehicle;
        
        Console.WriteLine("Most expensive vehicle:");
        sortedVehicles.First().DisplayInfo();
    }

    public static void FindVehiclesExceedingSpeed(double speed)
    {
        Console.WriteLine($"Vehicles with speed greater than {speed}:");
        bool found = false;
        
        var exceedingSpeed = from vehicle in VehicleManager.Vehicles
                     where vehicle.Speed > speed
                     select vehicle;

        foreach (var vehicle in exceedingSpeed)
        {
            vehicle.DisplayInfo();
            found = true;
        }
        
        if (!found)
        {
            Console.WriteLine("None found.");
        }
    }

    public static void FindTrucksExceedingLoadCapacity(double loadCapacity)
    {
        Console.WriteLine($"Trucks with capacity greater than {loadCapacity}:");
        bool found = false;

        var exceedingCapacity = from vehicle in VehicleManager.Vehicles
                                where vehicle is Truck truck && truck.LoadCapacity > loadCapacity
                                select vehicle;

        foreach (var vehicle in exceedingCapacity)
        {
            vehicle.DisplayInfo();
            found = true;
        }
        
        if (!found)
        {
            Console.WriteLine("None found.");
        }
    }

    public static void FindAveragePricePerType()
    {
        var averagePricesByType = from vehicle in VehicleManager.Vehicles
                                 group vehicle by vehicle.GetType().Name into typeGroup
                                 where VehicleConstants.VEHICLE_TYPES.Contains(typeGroup.Key)
                                 select new { Type = typeGroup.Key, AveragePrice = typeGroup.Average(v => v.Price) };

        foreach (var typePriceInfo in averagePricesByType)
        {
            Console.WriteLine($"Average price of {typePriceInfo.Type}: {typePriceInfo.AveragePrice:C}");
        }
    }

    public static void FindAveragePriceOfAllVehicles()
    {
        if (VehicleManager.Vehicles.Length == 0)
        {
            Console.WriteLine("No vehicles in the system.");
            return;
        }

        double averagePrice = VehicleManager.Vehicles.Average(v => v.Price);
        Console.WriteLine($"Average price of all vehicles: {averagePrice:C}");
    }

    public static void CountEachType()
    {
        var vehicleCountsByType = from vehicle in VehicleManager.Vehicles
                                 group vehicle by vehicle.GetType().Name into typeGroup
                                 where VehicleConstants.VEHICLE_TYPES.Contains(typeGroup.Key)
                                 select new { Type = typeGroup.Key, Count = typeGroup.Count() };

        foreach (var typeCountInfo in vehicleCountsByType)
        {
            Console.WriteLine($"Number of {typeCountInfo.Type}: {typeCountInfo.Count}");
        }
    }

    public static void FindFastestPerCategory()
    {
        var fastestVehiclesByCategory = from vehicle in VehicleManager.Vehicles
                                       group vehicle by vehicle.VehicleType into categoryGroup
                                       select categoryGroup.OrderByDescending(v => v.Speed).First();

        foreach (var fastestVehicle in fastestVehiclesByCategory)
        {
            Console.WriteLine($"Fastest {fastestVehicle.VehicleType}:");
            fastestVehicle.DisplayInfo();
            Console.WriteLine();
        }
    }
}
