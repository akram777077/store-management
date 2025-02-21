using AutoMapper;
using Core.Bases;
using Core.Featurs.Users.Commands.Requests;
using Core.Localization;
using Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Users.Commands.Handler
{
    public class UserCommandHandler : ResponseHandler,
                IRequestHandler<CreateUserCommand, Response<string>>,
                IRequestHandler<DeleteUserCommand, Response<string>>,
                IRequestHandler<UpdateUserCommand, Response<string>>,
                IRequestHandler<ResetPasswordCommand, Response<string>>,
                IRequestHandler<UnDeleteUserCommad, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _sharedResources;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        #endregion

        #region Constructors
        public UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                  IMapper mapper,
                                  UserManager<User> userManager,
                                  IUserService userService) : base(stringLocalizer)
        {
            _mapper = mapper;
            _sharedResources = stringLocalizer;
            _userManager = userManager;
            _userService = userService;
        }
        #endregion

        #region Actions
        public async Task<Response<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var identityUser = _mapper.Map<User>(request);
            //Create
            var createResult = await _userService.AddUserAsync(identityUser, request.Password);
            return createResult == "Success" ? Success("") : BadRequest<string>(createResult);
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var oldUser = await _userManager.FindByIdAsync(request.Id);

            if (oldUser == null) return NotFound<string>();

            var newUser = _mapper.Map(request, oldUser);

            //update
            var result = await _userManager.UpdateAsync(newUser);
            //result is not success
            if (!result.Succeeded) return BadRequest<string>(_sharedResources[SharedResourcesKeys.UpdateFailed]);
            //message
            return Success((string)_sharedResources[SharedResourcesKeys.Updated]);
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //check if Id exists
            var user = await _userManager.FindByIdAsync(request.Id);

            //return not found if not exist
            if (user == null)
                return NotFound<string>();

            //cal the delete service
            var result = await _userManager.DeleteAsync(user);

            //return response
            if (result.Succeeded) return Deleted<string>("");
            else return InternalServerError<string>(result.Errors.FirstOrDefault().Description);
        }
        public async Task<Response<string>> Handle(UnDeleteUserCommad request, CancellationToken cancellationToken)
        {
            //check if Id exists
            var user = await _userManager.Users.IgnoreQueryFilters()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            //return not found if not exist
            if (user == null)
                return NotFound<string>();

            //cal the edit service
            user.IsDeleted = false;
            var result = await _userManager.UpdateAsync(user);

            //return response
            if (result.Succeeded) return Success("");
            else return InternalServerError<string>(result.Errors.FirstOrDefault().Description);
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null) return NotFound<string>();

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success((string)_sharedResources[SharedResourcesKeys.Success]);

        }

        #endregion

    }
}
