using System;

namespace Exceptions
{
    public class InvalidSpeedException : VehicleException
    {
        public InvalidSpeedException() : base() { }
        public InvalidSpeedException(string message) : base(message) { }
        public InvalidSpeedException(string message, Exception inner) : base(message, inner) { }
    }
}
