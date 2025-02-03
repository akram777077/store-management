using System;
using AutoMapper;
using Core.Bases;
using Core.Featurs.Categories.Queries.Responses;
using Core.Featurs.UnitType.Query.Request;
using Core.Featurs.UnitType.Query.Response;
using Core.Localization;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.UnitType.Query.Handler;

public class UnitTypesQueryHandler: ResponseHandler,
    IRequestHandler<GetUnitTypesListRequest, Response<IEnumerable<GetUnitTypesResponse>>>,
    IRequestHandler<GetUnitTypeByNameRequest, Response<GetUnitTypeResponse>>,
    IRequestHandler<GetUnitTypeByIdRequest, Response<GetUnitTypeResponse>>
{
    private readonly IUnitTypeService _unitTypeService;
    private readonly IStringLocalizer<SharedResources> _localizer;
    private readonly IMapper _mapper;

    public UnitTypesQueryHandler(IUnitTypeService unitTypeService, IStringLocalizer<SharedResources> localizer, IMapper mapper)
    : base(localizer)
    {
        _unitTypeService = unitTypeService;
        _localizer = localizer;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<GetUnitTypesResponse>>> Handle(GetUnitTypesListRequest request, CancellationToken cancellationToken)
    {
        var unitTypes = await _unitTypeService.GetListAsync();
        var unitTypesList = _mapper.Map<IEnumerable<GetUnitTypesResponse>>(unitTypes);
        return Success(unitTypesList);
    }

    public async Task<Response<GetUnitTypeResponse>> Handle(GetUnitTypeByNameRequest request, CancellationToken cancellationToken)
    {
        var entity = await _unitTypeService.GetUnitTypesByNameAsync(request.Name);
        if (entity is null)
            return NotFound<GetUnitTypeResponse>();
        var entityMap = _mapper.Map<GetUnitTypeResponse>(entity);
        return Success(entityMap);
    }

    public async Task<Response<GetUnitTypeResponse>> Handle(GetUnitTypeByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await _unitTypeService.GetByIdAsync(request.Id);
        if (entity is null)
            return NotFound<GetUnitTypeResponse>();
        var entityMap = _mapper.Map<GetUnitTypeResponse>(entity);
        return Success(entityMap);
    }
}
