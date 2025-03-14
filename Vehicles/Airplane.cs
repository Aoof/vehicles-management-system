using System;
using Exceptions;

namespace Vehicles
{
    public class Airplane : Vehicle
    {
        public double Altitude { get; set; }

        public Airplane() : base()
        {
            Altitude = 0;
        }

        public Airplane(string name, double price, double speed, string vehicleType, double altitude) : base(name, price, speed, vehicleType)
        {
            Altitude = altitude;
        }

        public Airplane(Airplane airplane) : base(airplane)
        {
            Altitude = airplane.Altitude;
        }

        public override double CalculateTax()
        {
            return Price * 0.1;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"This {VehicleType} is named {Name}, costs ${Price}, can go {Speed} mph, and flies at an altitude of {Altitude} feet."
            );
        }
    }
}