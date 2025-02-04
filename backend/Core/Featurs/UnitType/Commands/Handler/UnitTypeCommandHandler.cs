using AutoMapper;
using Core.Bases;
using Core.Featurs.UnitType.Commands.Requests;
using Core.Localization;
using Infrastracture.Data;
using Infrastracture.Repositories;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceImplementations;

namespace Core.Featurs.UnitType.Commands.Handler;

public class UnitTypeCommandHandler(
    IStringLocalizer<SharedResources> localizer,
    IUnitTypeService service,
    IMapper mapper)
    : ResponseHandler(localizer),
        IRequestHandler<CreateUnitTypeCommand, Response<string>>,
        IRequestHandler<DeleteUnitTypeByIdCommand, Response<string>>
{
    private readonly IStringLocalizer<SharedResources> _localizer = localizer;
    private readonly IUnitTypeService _service = service;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<string>> Handle(CreateUnitTypeCommand request, CancellationToken cancellationToken)
    {
        var unitType = _mapper.Map<Data.Entities.UnitType>(request);
        await _service.AddAsync(unitType);
        return Created("");
    }

    public async Task<Response<string>> Handle(DeleteUnitTypeByIdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id < 1)
            return BadRequest<string>();
        var entity = await _service.GetByIdAsync(request.Id);
        if (entity is null)
            return NotFound<string>();
        await _service.DeleteAsync(entity);
        return NoContent<string>("");
    }
}