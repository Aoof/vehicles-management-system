namespace UserInterface;

using System;
using Vehicles;
using IndependentClasses;
using Services;

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
        // Run the GUI version of the program
    }

    public static void Run_CLI()
    {
        Console.WriteLine("Running CLI version of the program... Use --gui or -g to run the GUI version.");

        Vehicle vehicle1 = new Car("Toyota", 10000, 200, typeof(Car).Name, 4, "Sedan");

        double tax1 = TaxCalculator.CalculateTax(vehicle1);
        Console.WriteLine($"Tax for {vehicle1.VehicleType} is {tax1}");
    }
}
