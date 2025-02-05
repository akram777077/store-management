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
        IRequestHandler<UnitTypeNameOnlyCommand, Response<string>>,
        IRequestHandler<DeleteUnitTypeByIdCommand, Response<string>>,
        IRequestHandler<UpdateUnitTypeCommand,Response<string>>
{
    private readonly IStringLocalizer<SharedResources> _localizer = localizer;
    private readonly IUnitTypeService _service = service;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<string>> Handle(UnitTypeNameOnlyCommand request, CancellationToken cancellationToken)
    {
        if (await IsDuplicateName(request))
            return Conflict("");
        var unitType = _mapper.Map<Data.Entities.UnitType>(request);
        await _service.AddAsync(unitType);
        return Created("");
    }
    private async Task<bool> IsDuplicateName(UnitTypeNameOnlyCommand request)
    {
        var entity = await _service.GetUnitTypesByNameAsync(request.Name);
        if (entity is null)
            return false;
        else if (request is UpdateUnitTypeCommand updateCommand)
        {
            return updateCommand.Id != entity.Id;
        }

        return true;
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

    public async Task<Response<string>> Handle(UpdateUnitTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _service.GetByIdAsync(request.Id);
        if (entity is null)
            return NotFound<string>();
        if (await IsDuplicateName(request))
            return Conflict("");
        entity.Name = request.Name;
        await _service.UpdateAsync(entity);
        return NoContent<string>();
    }
}