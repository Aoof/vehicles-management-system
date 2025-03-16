using System;
using Exceptions;

namespace Vehicles
{
    public class CargoAirplane : Airplane
    {
        public double CargoCapacity { get; set; }

        public CargoAirplane() : base()
        {
            CargoCapacity = 1;
        }

        public CargoAirplane(string name, double price, double speed, string vehicleType, double altitude, double cargoCapacity) : base(name, price, speed, vehicleType, altitude)
        {
            if (cargoCapacity < 0) throw new InvalidCargoCapacityException("Cargo capacity cannot be negative.");
        
            CargoCapacity = cargoCapacity;
        }

        public CargoAirplane(CargoAirplane cargoAirplane) : base(cargoAirplane)
        {
            CargoCapacity = cargoAirplane.CargoCapacity;
        }

        public override void LoadFromStringArray(string[] values)
        {
            base.LoadFromStringArray(values);
            CargoCapacity = Convert.ToDouble(values[ICARGOCAPACITY]);
        }

        public override double CalculateTax()
        {
            return Price * 0.2;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"This {VehicleType} is named {Name}, costs ${Price}, can go {Speed} mph, flies at an altitude of {Altitude} feet, and can carry {CargoCapacity} tons of cargo."
            );
        }

        public override string GetSpecialFeatures()
        {
            return $"Altitude: {Altitude} ft, Capacity: {CargoCapacity} tons";
        }
    }
}