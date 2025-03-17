using System;

namespace Exceptions;

public class FileHandlingException : Exception
{
    public FileHandlingException(string message) : base(message) { }
    public FileHandlingException(string message, Exception innerException) : base(message, innerException) { }
    public FileHandlingException() { }
}
