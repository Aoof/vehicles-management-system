namespace IndependentClasses;

using System;
using System.Linq;
using System.Collections.Generic;
using Services;
using Vehicles;
using Common;

public static class VehicleStatistics
{
    public static Vehicle? FindMostEpensiveVehicle()
    {
        if (VehicleManager.Vehicles.Length == 0)
        {
            return null;
        }
        
        var sortedVehicles = from vehicle in VehicleManager.Vehicles
                             orderby vehicle.Price descending
                             select vehicle;
        
        return sortedVehicles.First();
    }

    public static IEnumerable<Vehicle> FindVehiclesExceedingSpeed(double speed)
    {
        var exceedingSpeed = from vehicle in VehicleManager.Vehicles
                             where vehicle.Speed > speed
                             select vehicle;

        return exceedingSpeed;
    }

    public static IEnumerable<Vehicle> FindTrucksExceedingLoadCapacity(double loadCapacity)
    {
        var exceedingCapacity = from vehicle in VehicleManager.Vehicles
                                where vehicle is Truck truck && truck.LoadCapacity > loadCapacity
                                select vehicle;

        return exceedingCapacity;
    }

    public static Dictionary<string, double> FindAveragePricePerType()
    {
        var averagePricesByType = from vehicle in VehicleManager.Vehicles
                                  group vehicle by vehicle.GetType().Name into typeGroup
                                  where VehicleConstants.VEHICLE_TYPES.Contains(typeGroup.Key)
                                  select new { Type = typeGroup.Key, AveragePrice = typeGroup.Average(v => v.Price) };
        
        Dictionary<string, double> result = new Dictionary<string, double>();
        
        foreach (var typePriceInfo in averagePricesByType)
        {
            result[typePriceInfo.Type] = typePriceInfo.AveragePrice;
        }
        
        return result;
    }

    public static double FindAveragePriceOfAllVehicles()
    {
        if (VehicleManager.Vehicles.Length == 0)
        {
            return 0;
        }

        double averagePrice = VehicleManager.Vehicles.Average(v => v.Price);
        
        return averagePrice;
    }

    public static Dictionary<string, int> CountEachType()
    {
        var vehicleCountsByType = from vehicle in VehicleManager.Vehicles
                                  group vehicle by vehicle.GetType().Name into typeGroup
                                  where VehicleConstants.VEHICLE_TYPES.Contains(typeGroup.Key)
                                  select new { Type = typeGroup.Key, Count = typeGroup.Count() };
        
        Dictionary<string, int> result = new Dictionary<string, int>();
        
        foreach (var typeCountInfo in vehicleCountsByType)
        {
            result[typeCountInfo.Type] = typeCountInfo.Count;
        }
        
        return result;
    }

    public static Dictionary<string, Vehicle> FindFastestPerCategory()
    {
        var fastestVehiclesByCategory = from vehicle in VehicleManager.Vehicles
                                        group vehicle by vehicle.VehicleType into categoryGroup
                                        select categoryGroup.OrderByDescending(v => v.Speed).First();

        Dictionary<string, Vehicle> result = new Dictionary<string, Vehicle>();
        
        foreach (var fastestVehicle in fastestVehiclesByCategory)
        {
            result[fastestVehicle.VehicleType] = fastestVehicle;
        }
        
        return result;
    }
}
