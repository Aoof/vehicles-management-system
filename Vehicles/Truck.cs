using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public double LoadCapacity { get; set; }

        public Truck() : base()
        {
            LoadCapacity = 1;
        }

        public Truck(string name, double price, double speed, string vehicleType, double loadCapacity) : base(name, price, speed, vehicleType)
        {
            LoadCapacity = loadCapacity;
        }

        public Truck(Truck truck) : base(truck)
        {
            LoadCapacity = truck.LoadCapacity;
        }

        public override double CalculateTax()
        {
            return Price * 0.1;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"This {VehicleType} is named {Name}, costs ${Price}, can go {Speed} mph, and has a load capacity of {LoadCapacity} ton(s)."
            );
        }
    }
}