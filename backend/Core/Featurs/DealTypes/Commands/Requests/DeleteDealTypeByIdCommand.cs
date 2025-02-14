using System;
using Core.Bases;
using MediatR;

namespace Core.Featurs.DealTypes.Commands.Requests;

public class DeleteDealTypeByIdCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
}
