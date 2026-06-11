namespace ConductorSdk.Models;

public class Error
{
    public string Message { get; set;} = string.Empty;
    public string UserFacingMessage { get; set;} = string.Empty;
    public string Type { get; set;} = string.Empty;
    public string Code { get; set;} = string.Empty;
    public int HttpStatusCode;
    public string RequestId { get; set;} = string.Empty;
}

public class ConductorErrorContainer
{
    public Error Error { get; set; } = new();
}