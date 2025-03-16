using System;
using Common;

namespace Vehicles
{
    public class Boat : Vehicle
    {
        public double SeatingCapacity { get; set; }

        public Boat() : base()
        {
            SeatingCapacity = 1;
        }

        public Boat(string name, double price, double speed, string vehicleType, double seatingCapacity) : base(name, price, speed, vehicleType)
        {
            SeatingCapacity = seatingCapacity;
        }

        public Boat(Boat boat) : base(boat)
        {
            SeatingCapacity = boat.SeatingCapacity;
        }

        public Boat(string[] values) : base(values)
        {
            SeatingCapacity = Convert.ToDouble(values[VehicleConstants.ISEATINGCAPACITY]);
        }

        public override string ToString()
        {
            return base.ToString() + $",{SeatingCapacity}";
        }

        public override double CalculateTax()
        {
            return Price * 0.05;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"This {VehicleType} is named {Name}, costs ${Price}, can go {Speed} mph, and has a seating capacity of {SeatingCapacity} seat(s)."
            );
        }

        public override string GetSpecialFeatures()
        {
            return $"Seats: {SeatingCapacity}";
        }
    }
}
