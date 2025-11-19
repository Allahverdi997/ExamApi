using Application.Abstraction;
using Application.Abstraction.AppConfig;
using Application.Abstraction.Service.Core.Auth;
using Application.Concrete;
using Application.Exceptions.Main;
using Application.Models.Data;
using Application.Models.Data.Core;
using Application.Models.Request.Core.Auth;
using Application.Models.Response.Core;
using Application.Models.Response.Core.Auth;
using Application.Models.Response.Core.Main;
using AutoMapper;
using Azure;
using Domain.Concrete.Core.Auth;
using FluentValidation;
using HashingService.Abstract;
using JWTService.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Core.Auth
{
    public class UserService:IUserService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IAppSession _appSession;
        protected readonly IAppSetting _appSetting;
        protected readonly ILogger<UserService> _logger;

        private readonly IValidator<LoginRequest> _loginValidator;

        private readonly IJWTService _jWTService;
        private readonly IHashService _hashService;

        public UserService(IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<UserService> logger,
            IAppSession appSession,
            IValidator<LoginRequest> loginValidator,
            IJWTService jWTService,
            IHashService hashService,
            IAppSetting appSetting)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _appSession = appSession;
            _loginValidator = loginValidator;
            _jWTService = jWTService;
            _hashService = hashService;
            _appSetting = appSetting;
        }


        public async Task<BaseResponseModel<List<UserRoleResponse>>> GetUserRolesAsync(int userId)
        {
            var userRoles = await _unitOfWork.UserRoleReadRepository.GetListAsync(ur => ur.UserId == userId);

            if (!userRoles.Any())
                throw new NotFoundException("Melumat tapilmadi");

            var mappedModel=_mapper.Map<List<UserRoleResponse>>(userRoles);

            return new SuccessReponseModel<List<UserRoleResponse>>(mappedModel);
        }

        public async Task<BaseResponseModel<string>> LoginAsync(LoginRequest request)
        {
            var result=_loginValidator.Validate(request);

            if(!result.IsValid)
            {
                var errors=result.Errors.Select(e=>new Error(new Content(e.PropertyName,e.ErrorMessage),e.ErrorMessage)).ToList();

                return new ErrorReponseModel<string>(errors);
            }

            var hashedPassword=_hashService.EncryptePassword(request.Password, _appSetting.HashKey);

            User user = await _unitOfWork.UserReadRepository
                              .GetSingleAsync(u => u.UserName == request.Username && u.Password == hashedPassword);

            if (user == null)
                throw new NotFoundException("Melumat tapilmadi");

            var userRoles = await _unitOfWork.UserRoleReadRepository.GetListAsync(ur => ur.UserId == user.Id,true);

            var claims =await GetClaimsAsync(user, userRoles);

            claims.Add(new Claim("Id", user.Id.ToString()));

            var token = _jWTService.GenerateToken(_appSetting.HashKey, claims, 2);

            user.RefreshToken = _jWTService.GenerateRefreshToken();
            user.RefreshTokenExpiration = DateTime.UtcNow.AddMinutes(5);

            await _unitOfWork.UserWriteRepository.UpdateAsync(user);
            await _unitOfWork.CommitAsync();

            return new SuccessReponseModel<string>(token);
        }

        private async Task<List<Claim>> GetClaimsAsync(User user, IEnumerable<UserRole>? userRoles)
        {
            var claims = new List<Claim>();

            if (!userRoles.Any())
            {
                claims.Add(new Claim("Name", user.UserName));
                claims.Add(new Claim("Id", user.Id.ToString()));
            }

            var roleIds=userRoles.Select(r => r.Id).ToList();

            var roles = await _unitOfWork.RoleReadRepository.GetListAsync(r => roleIds.Contains(r.Id),true);

            var role= string.Join(",", roles.Select(r => r.Name));

            claims.Add(new Claim("Roles", role));

            return claims;
        }

        public async Task<BaseResponseModel<List<UserRoleResponse>>> SetRolesAsync(int userId, List<int> roles)
        {
            var newUserRoles=new List<UserRole>();

            var user=await _unitOfWork.UserReadRepository.Get(u=>u.Id==userId).FirstOrDefaultAsync();

            if (user == null)
                throw new NotFoundException("Melumat tapilmadi");

            var userRoles=await _unitOfWork.UserRoleReadRepository.GetListAsync(ur=>ur.UserId==userId);

            foreach (var role in userRoles)
            {
                if(roles.Contains(role.Id))
                    roles.Remove(role.Id);
                else
                    newUserRoles.Add(new UserRole() { ExpiredDate=DateTime.Now.AddYears(1), RoleId=role.Id, UserId=user.Id});
            }

            await _unitOfWork.UserRoleWriteRepository.AddRangeAsync(newUserRoles);
            await _unitOfWork.CommitAsync(_appSession.Token);

            var mappedModel = _mapper.Map<List<UserRoleResponse>>(userRoles);

            return new SuccessReponseModel<List<UserRoleResponse>>(mappedModel);
        }

        public async Task<BaseResponseModel<UserResponse>> SignInAsync(SaveUserRequest userRequest)
        {
            var user=_mapper.Map<User>(userRequest);

            var encryptedPass = _hashService.EncryptePassword(userRequest.Password, _appSetting.HashKey);

            user.ExpiredDate = DateTime.Now.AddYears(1);
            user.Password = encryptedPass;

            await _unitOfWork.UserWriteRepository.AddAsync(user);
            await _unitOfWork.CommitAsync(_appSession.Token);

            var mappedData= _mapper.Map<UserResponse>(user);

            return new SuccessReponseModel<UserResponse>(mappedData);
        }

        public async Task<BaseResponseModel<List<Role>>> GetRolesAsync()
        {
            var roles = await _unitOfWork.RoleReadRepository.GetListAsync();

            if (!roles.Any())
                throw new NotFoundException("Data not found");

            return new SuccessReponseModel<List<Role>>(roles.ToList());
        }
    }
}
