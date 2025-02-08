using AutoMapper;
using Core.Bases;
using Core.Featurs.UnitTypes.Commands.Requests;
using Core.Localization;
using Data.Entities;
using Infrastracture.Data;
using Infrastracture.Repositories;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceImplementations;

namespace Core.Featurs.UnitTypes.Commands.Handler;

public class UnitTypeCommandHandler
    : ResponseHandler,
        IRequestHandler<CreateUnitTypeCommand, Response<string>>,
        IRequestHandler<DeleteUnitTypeByIdCommand, Response<string>>,
        IRequestHandler<UpdateUnitTypeCommand,Response<string>>
{
    #region Properties
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IUnitTypeService _unitTypeService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor
    public UnitTypeCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IUnitTypeService service, IMapper mapper)
        : base(stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
        _unitTypeService = service;
        _mapper = mapper;
    }
    #endregion

    #region Function Handling

    public async Task<Response<string>> Handle(CreateUnitTypeCommand request, CancellationToken cancellationToken)
    {
        var unitType = _mapper.Map<UnitType>(request);
        var response = await _unitTypeService.AddAsync(unitType);

        return Created("");
    }

    public async Task<Response<string>> Handle(DeleteUnitTypeByIdCommand request, CancellationToken cancellationToken)
    {
        // quick validation for the Id
        if (request.Id < 1)
            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

        //check if Id exists
        var unitType = await _unitTypeService.GetByIdAsync(request.Id);

        //return not found if not exist
        if (unitType == null)
            return NotFound<string>();

        //cal the edit service
        var result = await _unitTypeService.DeleteAsync(unitType);

        //return response
        if (result == "Deleted")
            return Deleted<string>("");
        else
            return InternalServerError<string>();
    }

    public async Task<Response<string>> Handle(UpdateUnitTypeCommand request, CancellationToken cancellationToken)
    {
        var unitType = await _unitTypeService.GetByIdAsync(request.Id);
        if (unitType == null)
            return NotFound<string>();

        _mapper.Map(request, unitType);

        await _unitTypeService.UpdateAsync(unitType);
        return Success("");
    }
    #endregion

}