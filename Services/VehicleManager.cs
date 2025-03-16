namespace Services;

using System;
using Vehicles;

public static class VehicleManager
{
    private static Vehicle[] vehicles = [];
    private static int count = 0;
    public static void AddVehicle(Vehicle vehicle)
    {
        Array.Resize(ref vehicles, count++);
        vehicles[count] = vehicle;
    }
}
