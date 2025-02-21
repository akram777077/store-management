using AutoMapper;
using Core.Bases;
using Core.Featurs.Users.Queries.Request;
using Core.Featurs.Users.Queries.Response;
using Core.Localization;
using Core.Wrapper;
using Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Users.Queries.Handler
{
    public class UserQueriesHandler : ResponseHandler,
        IRequestHandler<GetUserByIdQuery, Response<GetUserResponse>>,
        IRequestHandler<GetUsersListQuery, PaginatedResult<GetUserResponse>>,
        IRequestHandler<GetUserByUsernameQuery, Response<GetUserResponse>>,
        IRequestHandler<GetUserByPhoneNumberQuery, Response<GetUserResponse>>,
        IRequestHandler<GetUserByEmailQuery, Response<GetUserResponse>>

    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _sharedResources;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructors
        public UserQueriesHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                  IMapper mapper,
                                  UserManager<User> userManager) : base(stringLocalizer)
        {
            _mapper = mapper;
            _sharedResources = stringLocalizer;
            _userManager = userManager;
        }
        #endregion

        #region Handle Functions
        public async Task<PaginatedResult<GetUserResponse>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var paginatedList = await _mapper.ProjectTo<GetUserResponse>(users)
                                            .ToPaginatedListAsync(request.PageNumber, request.PageNumber);
            return paginatedList;
        }
        
        public async Task<Response<GetUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null) return NotFound<GetUserResponse>(_sharedResources[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetUserResponse>(user);
            return Success(result);
        }

        public async Task<Response<GetUserResponse>> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null) return NotFound<GetUserResponse>(_sharedResources[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetUserResponse>(user);
            return Success(result);
        }

        public async Task<Response<GetUserResponse>> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken);
            if (user == null) return NotFound<GetUserResponse>(_sharedResources[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetUserResponse>(user);
            return Success(result);
        }

        public async Task<Response<GetUserResponse>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return NotFound<GetUserResponse>(_sharedResources[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetUserResponse>(user);
            return Success(result);
        }
        #endregion

    }
}
