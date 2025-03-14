using System;
using Exceptions;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Speed { get; set; }
        public string VehicleType { get; set; }

        protected Vehicle()
        {
            Name = "Unknown";
            Price = 1;
            Speed = 1;
            VehicleType = "Unknown";
        }

        protected Vehicle(string name, double price, double speed, string vehicleType)
        {
            if (price < 0) throw new InvalidPriceException("Price cannot be negative.");
            if (speed < 0) throw new InvalidSpeedException("Speed cannot be negative.");

            Name = name;
            Price = price;
            Speed = speed;
            VehicleType = vehicleType;
        }

        protected Vehicle(Vehicle vehicle)
        {
            Name = vehicle.Name;
            Price = vehicle.Price;
            Speed = vehicle.Speed;
            VehicleType = vehicle.VehicleType;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine(
                $"This {VehicleType} is named {Name}, costs ${Price}, and can go {Speed} mph."
            );
        }

        public abstract double CalculateTax();
    }
}