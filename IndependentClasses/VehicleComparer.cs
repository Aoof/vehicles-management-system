namespace IndependentClasses;

using System;
using Vehicles;

public static class VehicleComparer 
{
    public static void Sort(Vehicle[] vehicles, Func<Vehicle, Vehicle, bool> compareMethod)
    {
        for (int i = 0; i < vehicles.Length - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < vehicles.Length - 1 - i; j++)
            {
                if (compareMethod(vehicles[j], vehicles[j + 1]))
                {
                    (vehicles[j], vehicles[j + 1]) = (vehicles[j + 1], vehicles[j]); 
                    swapped = true;
                }
            }
            if (!swapped) break;
        }
    }
    public static void Compare(Vehicle v1, Vehicle v2) => v1.Equals(v2);

    private static bool ShouldSwapSpeed(Vehicle v1, Vehicle v2) => v1.Speed > v2.Speed;
    private static bool ShouldSwapPrice(Vehicle v1, Vehicle v2) => v1.Price > v2.Price;
    private static bool ShouldSwapType(Vehicle v1, Vehicle v2) => string.Compare(v1.VehicleType, v2.VehicleType) > 0;

    public static void SortBySpeed(Vehicle[] vehicles) => Sort(vehicles, ShouldSwapSpeed);
    public static void SortByPrice(Vehicle[] vehicles) => Sort(vehicles, ShouldSwapPrice);
    public static void SortByType(Vehicle[] vehicles) => Sort(vehicles, ShouldSwapType);
}
