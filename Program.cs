using Exceptions;

namespace vehicles_management_system
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Vehicle Errors: " + VehicleException.VehicleErrors);
                throw new InvalidPriceException("Invalid price");
            } catch (VehicleException e)
            {
                Console.WriteLine("Vehicle Errors: " + VehicleException.VehicleErrors);
                Console.WriteLine(e.Message);
            }
        }
    }
}