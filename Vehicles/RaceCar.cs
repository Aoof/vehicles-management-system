using System;

namespace Vehicles
{
    public class RaceCar : Vehicle
    {
        public bool TurboBoost { get; set; }

        public RaceCar() : base()
        {
            TurboBoost = false;
        }

        public RaceCar(string name, double price, double speed, string vehicleType, bool turboBoost) : base(name, price, speed, vehicleType)
        {
            TurboBoost = turboBoost;
        }

        public override double CalculateTax()
        {
            return Price * 0.15;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"This {VehicleType} is named {Name}, costs ${Price}, can go {Speed} mph, and {(TurboBoost ? "has" : "does not have")} turbo boost."
            );
        }
    }
}