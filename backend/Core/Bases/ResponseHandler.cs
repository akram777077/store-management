using System;
using System.Net;
using Core.SharedResources;
using Microsoft.Extensions.Localization;

namespace Core.Bases;

public class ResponseHandler
{
    private readonly IStringLocalizer _stringLocalizer;


    public ResponseHandler(IStringLocalizer stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
    }

    public Response<T> Deleted<T>(string? message = null)
    {
        return Response<T>
            .CreateBuilder()
            .WithStatusCode(HttpStatusCode.OK)
            .WithSucceeded(true)
            .WithMessage(message ?? _stringLocalizer[Keys.Deleted])
            .Build();
    }

    public Response<T> InternalServerError<T>()
    {
        return Response<T>
            .CreateBuilder()
            .WithStatusCode(HttpStatusCode.InternalServerError)
            .WithSucceeded(false)
            .WithMessage("InternalServerError")
            .Build();
    }

    public Response<T> Success<T>(T entity, object? meta = null)
    {
        return Response<T>
            .CreateBuilder()
            .WithData(entity)
            .WithStatusCode(HttpStatusCode.OK)
            .WithSucceeded(true)
            .WithMessage(_stringLocalizer[Keys.Success])
            .WithMeta(meta)
            .Build();
    }

    public Response<T> Unauthorized<T>(string? message = null)
    {
        return Response<T>
            .CreateBuilder()
            .WithStatusCode(HttpStatusCode.Unauthorized)
            .WithSucceeded(false)
            .WithMessage(message ?? _stringLocalizer[Keys.UnAuthorized])
            .Build();
    }

    public Response<T> BadRequest<T>(string? message = null)
    {
        return Response<T>
            .CreateBuilder()
            .WithStatusCode(HttpStatusCode.BadRequest)
            .WithSucceeded(false)
            .WithMessage(message ?? _stringLocalizer[Keys.BadRequest])
            .Build();
    }

    public Response<T> UnprocessableEntity<T>(string? message = null)
    {
        return Response<T>
            .CreateBuilder()
            .WithStatusCode(HttpStatusCode.UnprocessableEntity)
            .WithSucceeded(false)
            .WithMessage(message ?? _stringLocalizer[Keys.UnprocessableEntity])
            .Build();
    }

    public Response<T> NotFound<T>(string? message = null)
    {
        return Response<T>
            .CreateBuilder()
            .WithStatusCode(HttpStatusCode.NotFound)
            .WithSucceeded(false)
            .WithMessage(message ?? _stringLocalizer[Keys.NotFound])
            .Build();
    }

    public Response<T> Created<T>(T entity, object? meta = null)
    {
        return Response<T>
            .CreateBuilder()
            .WithData(entity)
            .WithStatusCode(HttpStatusCode.Created)
            .WithSucceeded(true)
            .WithMessage(_stringLocalizer[Keys.Created])
            .WithMeta(meta)
            .Build();
    }

    public Response<T> Conflict<T>(T entity, object? meta = null)
    {
        return Response<T>
            .CreateBuilder()
            .WithData(entity)
            .WithStatusCode(HttpStatusCode.Conflict)
            .WithSucceeded(false)
            .WithMessage(_stringLocalizer[Keys.Conflict])
            .WithMeta(meta)
            .Build();
    }
}