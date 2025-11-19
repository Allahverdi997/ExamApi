using Application.Abstraction;
using Application.Abstraction.AppConfig;
using Application.Abstraction.Service.Core;
using Application.Exceptions.Main;
using AutoMapper;
using JWTService.Abstract;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete.Service
{
    public class FilterService : IFilterService
    {
        private readonly IAppSession _appSession;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppSetting _appSetting;
        public IJWTService JWTService { get; set; }

        public FilterService(
            IAppSession appSession,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IAppSetting appSettings,
            IJWTService jWTService
            )
        {
            _appSession = appSession;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appSetting = appSettings;
            JWTService = jWTService;
        }

        void IFilterService.AuthenticateUser(string token,string roles="")
        {
            if (string.IsNullOrEmpty(token))
                throw new AuthenticationException("UnAuthorizedException");

            if (!JWTService.VerifyToken(token))
                throw new AuthenticationException("Expired Token");

            var authenticated=AuthorizateRoles(token,roles);

            if (!authenticated)
                throw new AuthorizationException($"Access error. You haven't {roles} role");

            _appSession.Token = token;
        }

        private bool AuthorizateRoles(string token,string roles)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenIngredient = handler.ReadJwtToken(token) as JwtSecurityToken;
            var claims = tokenIngredient.Claims.ToList();

            var methodRoles=roles.Split(',').ToList();

            if (!roles.Any())
                return true;

            var userRoles = JWTService.DegenerateToken(token, "Roles").Value.Split(",").ToList();

            foreach(var role in methodRoles)
            {
                if (userRoles.Contains(role.ToUpper()))
                    return true;
            }

            return false;
        }
    }
}
