using System;
using AutoMapper;
using Core.Bases;
using Core.Featurs.Categories.Queries.Responses;
using Core.Featurs.UnitTypes.Query.Request;
using Core.Featurs.UnitTypes.Query.Response;
using Core.Localization;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.UnitTypes.Query.Handler;

public class UnitTypesQueryHandler: ResponseHandler,
    IRequestHandler<GetUnitTypesListRequest, Response<IEnumerable<GetUnitTypeResponse>>>,
    IRequestHandler<GetUnitTypeByNameRequest, Response<GetUnitTypeResponse>>,
    IRequestHandler<GetUnitTypeByIdRequest, Response<GetUnitTypeResponse>>
{
    private readonly IUnitTypeService _unitTypeService;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IMapper _mapper;

    public UnitTypesQueryHandler(IUnitTypeService unitTypeService, IStringLocalizer<SharedResources> localizer, IMapper mapper)
    : base(localizer)
    {
        _unitTypeService = unitTypeService;
        _stringLocalizer = localizer;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<GetUnitTypeResponse>>> Handle(GetUnitTypesListRequest request, CancellationToken cancellationToken)
    {
        var unitTypes = await _unitTypeService.GetListAsync();
        var unitTypesList = _mapper.Map<IEnumerable<GetUnitTypeResponse>>(unitTypes);
        return Success(unitTypesList);
    }

    public async Task<Response<GetUnitTypeResponse>> Handle(GetUnitTypeByNameRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Name))
            return BadRequest<GetUnitTypeResponse>(nameof(request.Name) + ": " + _stringLocalizer[SharedResourcesKeys.NotEmpty]);

        var entity = await _unitTypeService.GetUnitTypesByNameAsync(request.Name);
        if (entity is null)
            return NotFound<GetUnitTypeResponse>();
        var entityMap = _mapper.Map<GetUnitTypeResponse>(entity);
        return Success(entityMap);
    }

    public async Task<Response<GetUnitTypeResponse>> Handle(GetUnitTypeByIdRequest request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<GetUnitTypeResponse>(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

        var entity = await _unitTypeService.GetByIdAsync(request.Id);
        if (entity is null)
            return NotFound<GetUnitTypeResponse>();
        var entityMap = _mapper.Map<GetUnitTypeResponse>(entity);
        return Success(entityMap);
    }
}
