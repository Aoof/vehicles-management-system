using System;
using Exceptions;
using Common;

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

        public Airplane(string[] values) : base(values)
        {
            Altitude = Convert.ToDouble(values[VehicleConstants.IALTITUDE]);
        }

        public override string ToString()
        {
            return base.ToString() + $",{Altitude}";
        }

        public override double CalculateTax()
        {
            return Price * 0.15;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"This {VehicleType} is named {Name}, costs ${Price}, can go {Speed} mph, and flies at an altitude of {Altitude} feet."
            );
        }

        public override string GetSpecialFeatures()
        {
            return $"Altitude: {Altitude} ft";
        }
    }
}