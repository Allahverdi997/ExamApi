using JWTService.Abstract;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JWTService.Concrete
{
    public class JWTService : IJWTService
    {
        public string GenerateToken(string tokenKey, List<Claim> claims, int durationMinutes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(tokenKey); // UTF8 yeterli

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(durationMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool VerifyToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenIngredient = handler.ReadJwtToken(token) as JwtSecurityToken;

            //if (tokenIngredient == null || tokenIngredient.UserId == 0)
            //    throw new UnauthorizedException(SystemNotificationCode.AuthenticationTokenIsNotValid);

            DateTime tokenExpiresAt = tokenIngredient.ValidTo;
            if (DateTime.UtcNow > tokenExpiresAt)
                return false;
            return true;
        }

        public Claim DegenerateToken(string token,string claimType)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;

            var jti = tokenS.Claims.First(claim => claim.Type == claimType);

            return jti;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
