using System;
using Common;

namespace Vehicles
{
    public class LuxuryYacht : Boat
    {
        public bool Helipad { get; set; }

        public LuxuryYacht() : base()
        {
            Helipad = false;
        }

        public LuxuryYacht(string name, double price, double speed, string vehicleType, double seatingCapacity, bool helipad) : base(name, price, speed, vehicleType, seatingCapacity)
        {
            Helipad = helipad;
        }

        public LuxuryYacht(LuxuryYacht luxuryYacht) : base(luxuryYacht)
        {
            Helipad = luxuryYacht.Helipad;
        }

        public LuxuryYacht(string[] values) : base(values)
        {
            Helipad = Convert.ToBoolean(values[VehicleConstants.IHELIPAD]);
        }

        public override string ToString()
        {
            return base.ToString() + $",{Helipad}";
        }

        public override double CalculateTax()
        {
            return Price * 0.1;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"This {VehicleType} is named {Name}, costs ${Price}, can go {Speed} mph, has a seating capacity of {SeatingCapacity} seat(s), and {(Helipad ? "has" : "does not have")} a helipad."
            );
        }

        public override string GetSpecialFeatures()
        {
            return $"Seats: {SeatingCapacity}, Helipad: {(Helipad ? "Yes" : "No")}";
        }
    }
}