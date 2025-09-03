namespace Articles.Contracts.Errors;

public class ErrorDto
{
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public string TraceId { get; set; }
}