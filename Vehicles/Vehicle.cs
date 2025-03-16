using System;
using Exceptions;
using Common;

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

        protected Vehicle(string[] values)
        {
            Name = values[VehicleConstants.INAME];
            Price = Convert.ToDouble(values[VehicleConstants.IPRICE]);
            Speed = Convert.ToDouble(values[VehicleConstants.ISPEED]);
            VehicleType = values[VehicleConstants.ITYPE];
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;

            Vehicle vehicle = (Vehicle)obj;
            const double epsilon = 0.0001; 
            bool sameName = Name == vehicle.Name;
            bool samePrice = Math.Abs(Price - vehicle.Price) < epsilon;
            bool sameSpeed = Math.Abs(Speed - vehicle.Speed) < epsilon;
            bool sameType = VehicleType == vehicle.VehicleType;
            
            return sameName && samePrice && sameSpeed && sameType;
        }

        public override string ToString()
        {
            return $"{GetType().Name},{Name},{Price},{Speed},{VehicleType}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price, Speed, VehicleType);
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine(
                $"This {VehicleType} is named {Name}, costs ${Price}, and can go {Speed} mph."
            );
        }


        public abstract string GetSpecialFeatures();
        public abstract double CalculateTax();
    }
}