namespace Services;
using System;
using System.IO;
using Vehicles;
using Common;

public static class FileHandler
{
    public static string DefaultFilePath { get; } = "../data/VMS_SaveFile.dat";
    public static string FilePath { get; set; } = "../data/VMS_SaveFile.dat";
    
    public static void SaveToFile()
    {
        using StreamWriter writer = new(FilePath);

        foreach (Vehicle vehicle in VehicleManager.Vehicles)
        { writer.WriteLine(vehicle.ToString()); }
    }

    public static void LoadFromFile()
    {
        if (!File.Exists(FilePath))
        {
            if (FilePath != DefaultFilePath)
            {
                Console.WriteLine("Save file not found. Attempting to load default save file.");
                FilePath = DefaultFilePath;
                LoadFromFile();
                return;
            }

            Console.WriteLine("No save file found.");
            return;
        }

        using StreamReader reader = new(FilePath);

        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            string[] values = line.Split(',');

            switch (values[VehicleConstants.IVEHICLETYPE])
            {
                case "Boat":
                    VehicleManager.AddVehicle(new Boat(values));
                    break;
                case "Truck":
                    VehicleManager.AddVehicle(new Truck(values));
                    break;
                case "Train":
                    VehicleManager.AddVehicle(new Train(values));
                    break;
                case "Car":
                    VehicleManager.AddVehicle(new Car(values));
                    break;
                case "Airplane":
                    VehicleManager.AddVehicle(new Airplane(values));
                    break;
                case "CargoAirplane":
                    VehicleManager.AddVehicle(new CargoAirplane(values));
                    break;
                case "LuxuryYacht":
                    VehicleManager.AddVehicle(new LuxuryYacht(values));
                    break;
                default:
                    Console.WriteLine("Invalid vehicle type found in save file.");
                    break;
            }
        }
    }
}