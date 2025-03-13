using System;

namespace Exceptions
{
    public class VehicleException : Exception
    {
        private static int vehicleErrors = 0;
        public static int VehicleErrors
        {
            get { return vehicleErrors; }
        }
        public VehicleException() : base() { vehicleErrors++; }
        public VehicleException(string message) : base(message) { vehicleErrors++; }
        public VehicleException(string message, Exception inner) : base(message, inner) { vehicleErrors++; }
    }
}
