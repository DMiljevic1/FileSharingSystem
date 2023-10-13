using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure;
using FileSharingSystem.Contract;
using FileSharingSystem.DTO;
using FileSharingSystem.Model.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;

namespace FileSharingSystem.Service
{
	public class AuthService : IAuthService
	{
		private readonly IAuthRepository _authRepository;
		private readonly IConfiguration _config;
		private readonly IHashService _hashService;
		private readonly ILogger<AuthService> _logger;
		public AuthService (IAuthRepository authRepository, IConfiguration config, IHashService hashService, ILogger<AuthService> logger)
		{
			_authRepository = authRepository;
			_config = config;
			_hashService = hashService;
			_logger = logger;
		}
		public async Task<User> Authenticate(UserLogin userLogin, CancellationToken cancellationToken)
		{
			return await _authRepository.GetUserByEmailAndPassword(userLogin.Email, _hashService.HashUserPassword(userLogin.Password), cancellationToken);
		}

		public async Task<LoginResponse> Generate(UserLogin userLogin, CancellationToken cancellationToken)
		{
			var loginResponse = new LoginResponse();
			var user = await Authenticate(userLogin, cancellationToken);
			if(user != null)
			{
				var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
				var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
				var claims = new[]
				{
					new Claim(ClaimTypes.Rsa, user.Id.ToString()),
					new Claim(ClaimTypes.NameIdentifier, user.Email)
				};
				var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"],
					claims,
					expires: DateTime.UtcNow.AddMinutes(double.Parse(_config["Jwt:Exp"])),
					signingCredentials: credentials);
				loginResponse.Success = true;
				loginResponse.Message = "User found.";
				loginResponse.Token = new JwtSecurityTokenHandler().WriteToken(token);
				_logger.LogDebug("Login passed. Message: {0}, Email: {1}, Password: {2}", loginResponse.Message, userLogin.Email, _hashService.HashUserPassword(userLogin.Password));
			}
			else
			{
				loginResponse.Success = false;
				loginResponse.Message = "User not found.";
				_logger.LogError("Login failed. Message: {0}, Email: {1}, Password: {2}", loginResponse.Message, userLogin.Email, _hashService.HashUserPassword(userLogin.Password));
			}
			return loginResponse;
		}
	}
}
