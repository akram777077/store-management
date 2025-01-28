using System.Net;

namespace Core.Bases;

public class Response<T>
{
    public HttpStatusCode StatusCode { get; }
    public object? Meta { get; }
    public bool Succeeded { get; }
    public string? Message { get; }
    public List<string>? Errors { get; }
    public T? Data { get; }
    private Response(HttpStatusCode statusCode, object? meta, bool succeeded, string? message, List<string>? errors, T? data)
    {
        StatusCode = statusCode;
        Meta = meta;
        Succeeded = succeeded;
        Message = message;
        Errors = errors;
        Data = data;
    }

    public class Builder
    {
        private HttpStatusCode _statusCode = HttpStatusCode.OK;
        private  object? _meta;
        private bool _succeeded = true;
        private  string? _message ;
        private List<string>? _errors;
        private T? _data;

        public Builder WithStatusCode(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
            return this;
        }

        public Builder WithMeta(object? meta)
        {
            _meta = meta;
            return this;
        }

        public Builder WithSucceeded(bool succeeded)
        {
            _succeeded = succeeded;
            return this;
        }

        public Builder WithMessage(string? message)
        {
            _message = message;
            return this;
        }

        public Builder WithErrors(List<string>? errors)
        {
            _errors = errors;
            return this;
        }

        public Builder WithData(T data)
        {
            _data = data;
            return this;
        }

        public Response<T> Build()
        {
            return new Response<T>(_statusCode, _meta, _succeeded, _message, _errors, _data);
        }
    }

    public static Builder CreateBuilder()
    {
        return new Builder();
    }
}