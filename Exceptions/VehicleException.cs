using System;

namespace Exceptions
{
    public class VehicleException : Exception
    {
        private static int vehicleErrors = 0;
        public static int VehicleErrors
        {
            get { return vehicleErrors; }
            private set { vehicleErrors = value; }
        }
        public VehicleException() : base() { VehicleErrors++; }
        public VehicleException(string message) : base(message) { VehicleErrors++; }
        public VehicleException(string message, Exception inner) : base(message, inner) { VehicleErrors++; }
    }
}
