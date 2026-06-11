using ConductorSdk.Models;

namespace ConductorSdk.Exceptions;

public class ConductorApiException : Exception
{
    public Error Error { get; }
    public ConductorApiException(Error error) : base(error.Message)
    {
        Error = error;
    }
}