using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ardalis.Specification;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PlannerPlus.Auth;
using PlannerPlus.Dto;
using PlannerPlus.Models;
using PlannerPlus.Specifications.Administrator;

namespace PlannerPlus.BusinessLogic
{
    public class AdministratorService:IAdministratorService
    {
        private readonly IRepositoryBase<Administrator> _repository;
        private readonly IPasswordHasher<Administrator> _hasher;

        public AdministratorService(IRepositoryBase<Administrator> repository,IPasswordHasher<Administrator> hasher)
        {
            _repository = repository;
            _hasher = hasher;
        }

        public async Task<LoginResultDto> LoginAsync(string username, string password)
        {
            var spec = new AdministratorByUserName(username);
            var existing = await _repository.GetBySpecAsync(spec);
            if (existing == null)
            {
                throw new Exception("Invalid UserName or Password");
            }

            if (_hasher.VerifyHashedPassword(existing, existing.Password, password) ==
                PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid UserName or Password");
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,existing.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,"Admin"),
            };
            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new LoginResultDto
            {
                Name = existing.Name,
                Surname = existing.Surname,
                Token = encodedJwt,
                UserName = existing.UserName
            };
        }

        public async Task RegisterAsync(Administrator administrator)
        {
            if (string.IsNullOrEmpty(administrator.UserName) || string.IsNullOrEmpty(administrator.Password))
            {
                throw new Exception("UserName or Password is wrong");
            }
            var spec = new AdministratorByUserName(administrator.UserName);
            var existing = await _repository.GetBySpecAsync(spec);
            if (existing != null)
            {
                throw new Exception("This UserName already exists");
            }

            administrator.Password = _hasher.HashPassword(administrator, administrator.Password);
            await _repository.AddAsync(administrator);
            await _repository.SaveChangesAsync();

        }
    }
}
