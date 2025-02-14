using System;
using AutoMapper;
using Core.Bases;
using Core.Featurs.DealTypes.Commands.Requests;
using Core.Localization;
using Data.Entities;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.DealTypes.Commands.Handler;

public class DealTypeCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IDealTypeService dealTypeService, IMapper mapper) : ResponseHandler(stringLocalizer),
    IRequestHandler<CreateDealTypeCommand, Response<string>>,
    IRequestHandler<UpdateDealTypeCommand, Response<string>>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer = stringLocalizer;
    private readonly IDealTypeService _dealTypeService = dealTypeService;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<string>> Handle(UpdateDealTypeCommand request, CancellationToken cancellationToken)
    {
        var dealType = await _dealTypeService.GetByIdAsync(request.Id);
        if (dealType == null)
            return NotFound<string>();

        _mapper.Map(request, dealType);

        await _dealTypeService.UpdateAsync(dealType);
        return Success("");
    }
    public async Task<Response<string>> Handle(CreateDealTypeCommand request, CancellationToken cancellationToken)
    {
        var dealType = _mapper.Map<DealType>(request);
        var response = await _dealTypeService.AddAsync(dealType);

        return Created("");
    }

    
}
