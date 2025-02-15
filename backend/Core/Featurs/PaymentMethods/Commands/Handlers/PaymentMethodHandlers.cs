using AutoMapper;
using Core.Bases;
using Core.Featurs.PaymentMethods.Commands.Requests;
using Core.Localization;
using Data.Entities;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.PaymentMethods.Commands.Handlers
{

    public class PaymentMethodHandlers(IStringLocalizer<SharedResources> stringLocalizer, IPaymentMethodService paymentMethodService, IMapper mapper) : ResponseHandler(stringLocalizer),
    IRequestHandler<CreatePaymentMethodCommand, Response<string>>,
    IRequestHandler<UpdatePaymentMethodCommand, Response<string>>,
    IRequestHandler<DeletePaymentMethodByIdCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer = stringLocalizer;
        private readonly IPaymentMethodService _paymentMethodService = paymentMethodService;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<string>> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var paymentMethod = _mapper.Map<PaymentMethod>(request);
            var response = await _paymentMethodService.AddAsync(paymentMethod);

            return Created("");
        }

        public async Task<Response<string>> Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var paymentMethod = await _paymentMethodService.GetByIdAsync(request.Id);
            if (paymentMethod == null)
                return NotFound<string>();

            _mapper.Map(request, paymentMethod);

            await _paymentMethodService.UpdateAsync(paymentMethod);
            return Success("");
        }

        public async Task<Response<string>> Handle(DeletePaymentMethodByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.Id < 1)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            var paymentMethod = await _paymentMethodService.GetByIdAsync(request.Id);
            if (paymentMethod == null)
                return NotFound<string>();

            var result = await _paymentMethodService.DeleteAsync(paymentMethod);
            if (result == "Deleted")
                return Deleted<string>("");

            return InternalServerError<string>();
        }
    }
}
