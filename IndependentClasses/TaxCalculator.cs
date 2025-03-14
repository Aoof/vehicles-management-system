using Vehicles;

namespace IndependentClasses
{
    public static class TaxCalculator
    {
        public static double CalculateTax(Vehicle vehicle)
        {
            return vehicle.CalculateTax();
        }       
    }
}