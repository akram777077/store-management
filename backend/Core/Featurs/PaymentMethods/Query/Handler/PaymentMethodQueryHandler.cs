using AutoMapper;
using Core.Bases;
using Core.Featurs.PaymentMethods.Query.Request;
using Core.Featurs.PaymentMethods.Query.Response;
using Core.Featurs.UnitTypes.Query.Request;
using Core.Featurs.UnitTypes.Query.Response;
using Core.Localization;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.PaymentMethods.Query.Handler
{
    public class PaymentMethodQueryHandler : ResponseHandler,
     IRequestHandler<GetPaymentMethodsListRequest, Response<IEnumerable<GetPaymentMethodResponse>>>,
     IRequestHandler<GetPaymentMethodByNameRequest, Response<GetPaymentMethodResponse>>,
     IRequestHandler<GetPaymentMethodByIdRequest, Response<GetPaymentMethodResponse>>
    {
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;

        public PaymentMethodQueryHandler(IPaymentMethodService paymentMethodService, IStringLocalizer<SharedResources> localizer, IMapper mapper)
        : base(localizer)
        {
            _paymentMethodService = paymentMethodService;
            _stringLocalizer = localizer;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetPaymentMethodResponse>>> Handle(GetPaymentMethodsListRequest request, CancellationToken cancellationToken)
        {
            var paymentMethods = await _paymentMethodService.GetListAsync();
            var paymentMethodsList = _mapper.Map<IEnumerable<GetPaymentMethodResponse>>(paymentMethods);
            return Success(paymentMethodsList);
        }

        public async Task<Response<GetPaymentMethodResponse>> Handle(GetPaymentMethodByNameRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
                return BadRequest<GetPaymentMethodResponse>(nameof(request.Name) + ": " + _stringLocalizer[SharedResourcesKeys.NotEmpty]);

            var entity = await _paymentMethodService.GetPaymentMethodByNameAsync(request.Name);
            if (entity is null)
                return NotFound<GetPaymentMethodResponse>();

            var entityMap = _mapper.Map<GetPaymentMethodResponse>(entity);
            return Success(entityMap);
        }

        public async Task<Response<GetPaymentMethodResponse>> Handle(GetPaymentMethodByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                return BadRequest<GetPaymentMethodResponse>(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            var entity = await _paymentMethodService.GetByIdAsync(request.Id);
            if (entity is null)
                return NotFound<GetPaymentMethodResponse>();
            
            var entityMap = _mapper.Map<GetPaymentMethodResponse>(entity);
            return Success(entityMap);
        }
    }
}
