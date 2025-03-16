using System;
using Common;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public int Horsepower { get; set; }
        public string Model { get; set; }

        public Car() : base()
        {
            Horsepower = 100;
            Model = "Unknown";
        }

        public Car(string name, double price, double speed, string vehicleType, int horsepower, string model) : base(name, price, speed, vehicleType)
        {
            Horsepower = horsepower;
            Model = model;
        }

        public Car(Car car) : base(car)
        {
            Horsepower = car.Horsepower;
            Model = car.Model;
        }

        public Car(string[] values) : base(values)
        {
            Horsepower = Convert.ToInt32(values[VehicleConstants.IHORSEPOWER]);
            Model = values[VehicleConstants.IMODEL];
        }

        public override string ToString()
        {
            return base.ToString() + $",{Horsepower},{Model}";
        }

        public override double CalculateTax()
        {
            return Price * 0.1;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"This {VehicleType} is named {Name}, costs ${Price}, can go {Speed} mph, has {Horsepower} horsepower, and is a {Model} model."
            );
        }

        public override string GetSpecialFeatures()
        {
            return $"HP: {Horsepower}, Model: {Model}";
        }
    }
}