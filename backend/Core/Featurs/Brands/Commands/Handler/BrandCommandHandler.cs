using AutoMapper;
using Core.Bases;
using Core.Localization;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using Data.Entities;
using Core.Featurs.Brands.Commands.Requests;


namespace Core.Featurs.Brands.Commands.Handler
{
    public class BrandCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IBrandService brandService, IMapper mapper) : ResponseHandler(stringLocalizer),
        IRequestHandler<CreateBrandCommand, Response<string>>,
        IRequestHandler<UpdateBrandCommand, Response<string>>,
        IRequestHandler<DeleteBrandByIdCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer = stringLocalizer;
        private readonly IBrandService _brandService = brandService;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<string>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Brand>(request);
            var response = await _brandService.AddAsync(brand);

            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandService.GetByIdAsync(request.Id);
            if (brand is null)
                return NotFound<string>();

            _mapper.Map(request, brand);

            await _brandService.UpdateAsync(brand);
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteBrandByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.Id < 1)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            var brand = await _brandService.GetByIdAsync(request.Id);
            if (brand is null)
                return NotFound<string>();

            var result = await _brandService.DeleteAsync(brand);
            if (result == "Deleted")
                return Deleted<string>("");

            return InternalServerError<string>();
        }
    }
}
