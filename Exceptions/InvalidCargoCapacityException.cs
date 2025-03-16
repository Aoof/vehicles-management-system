namespace Exceptions;
using System;

public class InvalidCargoCapacityException : VehicleException
{
    public InvalidCargoCapacityException() : base() { }
    public InvalidCargoCapacityException(string message) : base(message) { }
    public InvalidCargoCapacityException(string message, Exception inner) : base(message, inner) { }
}
