namespace Exceptions;
using System;

public class InvalidPriceException : VehicleException
{
    public InvalidPriceException() : base() { }
    public InvalidPriceException(string message) : base(message) { }
    public InvalidPriceException(string message, Exception inner) : base(message, inner) { }
}
