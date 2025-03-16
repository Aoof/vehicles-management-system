using System;

namespace Vehicles
{
    public class RaceCar : Car
    {
        public bool TurboBoost { get; set; }

        public RaceCar() : base()
        {
            TurboBoost = false;
        }

        public RaceCar(string name, double price, double speed, string vehicleType, int horsepower, string model, bool turboBoost) : base(name, price, speed, vehicleType, horsepower, model)
        {
            TurboBoost = turboBoost;
        }

        public override void LoadFromStringArray(string[] values)
        {
            base.LoadFromStringArray(values);
            TurboBoost = Convert.ToBoolean(values[ITURBOBOOST]);
        }

        public override double CalculateTax()
        {
            return Price * 0.15;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"This {VehicleType} is named {Name}, costs ${Price}, can go {Speed} mph, has {Horsepower} horsepower, is a {Model}, and {(TurboBoost ? "has" : "does not have")} turbo boost."
            );
        }

        public override string GetSpecialFeatures()
        {
            return $"HP: {Horsepower}, Model: {Model}, Turbo: {(TurboBoost ? "Yes" : "No")}";
        }
    }
}