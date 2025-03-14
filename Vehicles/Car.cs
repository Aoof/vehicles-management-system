using System;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public int Horsepower { get; set; }
        public string Model { get; set; }

        public Car() : base()
        {
            Horsepower = 1;
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

        public override double CalculateTax()
        {
            return Price * 0.1;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"This {VehicleType} is named {Name}, costs ${Price}, can go {Speed} mph, has {Horsepower} horsepower, and is a {Model}."
            );
        }
    }
}