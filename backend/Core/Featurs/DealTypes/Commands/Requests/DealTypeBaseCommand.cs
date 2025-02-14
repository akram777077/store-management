using System;
using Core.Bases;
using MediatR;

namespace Core.Featurs.DealTypes.Commands.Requests;

public class DealTypeBaseCommand : IRequest<Response<string>>
{
    public required string Name { get; set; }
}
