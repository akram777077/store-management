using AutoMapper;
using Core.Bases;
using Core.Featurs.SaleTypes.Commands.Requests;
using Core.Localization;
using Data.Entities;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.SaleTypes.Commands.Handlers
{
    public class SaleTypeCommandHandler : ResponseHandler,
       IRequestHandler<CreateSaleTypeCommand, Response<string>>,
       IRequestHandler<UpdateSaleTypeCommand, Response<string>>,
       IRequestHandler<DeleteSaleTypeCommand, Response<string>>
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly ISaleTypeService _saleTypeService;
        #endregion

        #region Constructor
        public SaleTypeCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, ISaleTypeService saleTypeService, IMapper mapper) 
            : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _saleTypeService = saleTypeService;
            _mapper = mapper;
        }
        #endregion

        #region Function Handling
        public async Task<Response<string>> Handle(UpdateSaleTypeCommand request, CancellationToken cancellationToken)
        {
            var saleType = await _saleTypeService.GetByIdAsync(request.Id);
            if (saleType == null)
                return NotFound<string>();

            _mapper.Map(request, saleType);

            await _saleTypeService.UpdateAsync(saleType);
            return Success("");
        }

        public async Task<Response<string>> Handle(CreateSaleTypeCommand request, CancellationToken cancellationToken)
        {
            var saleType = _mapper.Map<SaleType>(request);
            var response = await _saleTypeService.AddAsync(saleType);

            return Created("");
        }

        public async Task<Response<string>> Handle(DeleteSaleTypeCommand request, CancellationToken cancellationToken)
        {
            if (request.Id < 1)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            var saleType = await _saleTypeService.GetByIdAsync(request.Id);
            if (saleType == null)
                return NotFound<string>();

            var result = await _saleTypeService.DeleteAsync(saleType);

            if (result == "Deleted") 
                return Deleted<string>("");
            
            return InternalServerError<string>();
        }
        #endregion
    }
}
