using System.Net;

namespace Core.Bases;

public class Response<T>
{

    public Response()
    {

    }
    public Response(T? data, string? message = null)
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }
    public Response(string? message)
    {
        Succeeded = false;
        Message = message;
    }
    public Response(string? message, bool succeeded)
    {
        Succeeded = succeeded;
        Message = message;
    }

    public HttpStatusCode StatusCode { get; set; }
    public object? Meta { get; set; }

    public bool Succeeded { get; set; }
    public string? Message { get; set; }
    public IEnumerable<string>? Errors { get; set; }
    //public Dictionary<string, IEnumerable<string>> ErrorsBag { get; set; }
    public T? Data { get; set; }
}


