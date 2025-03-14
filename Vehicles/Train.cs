using System;

namespace Vehicles
{
    public class Train : Vehicle
    {
        public int Units { get; set; }

        public Train() : base()
        {
            Units = 1;
        }

        public Train(string name, double price, double speed, string vehicleType, int units) : base(name, price, speed, vehicleType)
        {
            Units = units;
        }

        public Train(Train train) : base(train)
        {
            Units = train.Units;
        }

        public override double CalculateTax()
        {
            return Price * 0.1;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"This {VehicleType} is named {Name}, costs ${Price}, can go {Speed} mph, and has a load capacity of {Units} units."
            );
        }
    }
}
